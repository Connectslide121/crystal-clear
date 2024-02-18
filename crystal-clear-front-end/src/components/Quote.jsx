import React from "react";
import { useLoaderData } from "react-router-dom";
import jsPDF from "jspdf";
import { toPng } from "html-to-image";

export async function QuoteLoader({ params }) {
  return JSON.parse(atob(params.quote));
}

export default function Quote() {
  const quote = useLoaderData();

  const downloadPdfDocument = () => {
    const node = document.getElementById("quote-card");

    toPng(node)
      .then((dataUrl) => {
        const pdf = new jsPDF({
          orientation: "portrait",
          unit: "px",
          format: "a4"
        });

        const imgProps = pdf.getImageProperties(dataUrl);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
        pdf.addImage(dataUrl, "PNG", 20, 20, pdfWidth - 40, pdfHeight - 20);
        pdf.save(`Crystal clear quote ${quote.id}.pdf`);
      })
      .catch((error) => {
        console.error("Something went wrong:", error);
      });
  };
  return (
    <section id="quote">
      <article id="quote-card" className="quote-card">
        <header>
          <div>
            <h3>Quote ID: </h3>
            <p>{quote.id}</p>
          </div>
          <div>
            <h3>City: </h3>
            <p>{quote.city.name}</p>
          </div>
        </header>
        <hr />
        <div className="quote-basic">
          <div>
            <h4>
              Price / m<sup>2</sup>
            </h4>
            <p>{quote.city.pricePerSquareMeter} kr</p>
          </div>
          <div>
            <h4>
              m<sup>2</sup> to clean
            </h4>
            <p>{quote.squareMeters}</p>
          </div>
          <div>
            <h4>Price</h4>
            <p>{quote.city.pricePerSquareMeter * quote.squareMeters} kr</p>
          </div>
        </div>
        <hr />
        {quote.selectedOptions.length > 0 && (
          <>
            <div className="quote-options">
              {quote.selectedOptions.map((option) => (
                <div className="quote-option" key={option.id}>
                  <h4>{option.name}</h4>
                  <p>{option.price} kr</p>
                </div>
              ))}
            </div>
            <hr />
          </>
        )}
        <div className="quote-total">
          <h4>Total price:</h4>
          <p>{quote.totalPrice} kr</p>
        </div>
      </article>
      <div className="quote-buttons">
        <a href="/">Back</a>
        <button onClick={downloadPdfDocument}>Download quote</button>
      </div>
    </section>
  );
}
