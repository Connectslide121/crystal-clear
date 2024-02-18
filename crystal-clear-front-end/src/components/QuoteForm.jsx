import React, { useState } from "react";
import { GetCities } from "../APIs/API";
import { Form, useLoaderData } from "react-router-dom";
import GetImages from "../APIs/Unsplash";

export async function QuoteFormAction({ request }) {
  const formData = await request.formData();
  const input = Object.fromEntries(formData);

  console.log({ input });
  return 0;
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
        <h2>Select a city to get a quote</h2>
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
                  value={city}
                  onChange={() => handleCityChange(city)}
                  checked={selectedCity && selectedCity === city}
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
                  <input type="checkbox" name="option" value={option.id} />{" "}
                  {option.name} (SEK {option.price})
                </label>
              </article>
            ))}
        </div>
        <div className="quote-form-submit">
          {selectedCity && (
            <>
              <input
                type="number"
                name="square-meters"
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
