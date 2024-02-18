import React from "react";
import getImages from "../APIs/Unsplash";

export default async function QuoteForm() {
  let image = await getImages("Stockholm");
  console.log(image);

  return (
    <section id="quote-form">
      <img src={image.urls.small} alt="" />
    </section>
  );
}
