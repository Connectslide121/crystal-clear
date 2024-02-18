import React, { useState } from "react";
import { GetCities, CreateQuote } from "../APIs/API";
import { Form, redirect, useLoaderData } from "react-router-dom";
import GetImages from "../APIs/Unsplash";

export async function QuoteFormAction({ request }) {
  const formData = await request.formData();
  const input = Object.fromEntries(formData);
  const city = JSON.parse(input.city);
  input.city = city;

  const selectedOptions = [];
  for (const [key, value] of formData) {
    if (key.startsWith("option")) {
      selectedOptions.push(JSON.parse(value));
    }
  }
  input.options = selectedOptions;

  const quote = await CreateQuote(input);

  console.log(quote);
  return redirect(`/quote/${btoa(JSON.stringify(quote))}`);
}

export async function QuoteFormLoader() {
  const cities = await GetCities();
  const fetchImagePromises = cities.map(async (city) => {
    const image = await GetImages(city.name);
    city.image = image.urls.regular;
  });

  await Promise.all(fetchImagePromises);
  return cities;
}
export default function QuoteForm() {
  const cities = useLoaderData();

  const [selectedCity, setSelectedCity] = useState("");

  const handleCityChange = (city) => {
    setSelectedCity(city);
  };

  return (
    <section id="quote-form">
      <header className="quote-form-header">
        <h2>Select a city:</h2>
      </header>
      <Form method="post">
        <div className="quote-form-cities">
          {cities.map((city) => (
            <article
              key={city.id}
              className={`quote-form-city ${
                selectedCity &&
                (selectedCity.id === city.id ? "selected" : "unselected")
              }`}
            >
              <label>
                <input
                  type="radio"
                  name="city"
                  value={JSON.stringify(city)}
                  onChange={() => handleCityChange(city)}
                  checked={selectedCity && selectedCity.id === city.id}
                />
                <img src={city.image} alt={city.name} />
                <h3>{city.name}</h3>
              </label>
            </article>
          ))}
        </div>
        <div className="quote-form-options">
          {selectedCity &&
            selectedCity.availableOptions.map((option) => (
              <article key={option.id} className="quote-form-option">
                <label>
                  <input
                    type="checkbox"
                    name={`option${option.id}`}
                    value={JSON.stringify(option)}
                  />{" "}
                  {option.name} ({option.price} kr)
                </label>
              </article>
            ))}
        </div>
        <div className="quote-form-submit">
          {selectedCity && (
            <>
              <input
                type="number"
                name="squareMeters"
                placeholder="Square meters"
                required
              />
              <button type="submit" className="quote-form-button">
                Get quote
              </button>
            </>
          )}
        </div>
      </Form>
    </section>
  );
}
