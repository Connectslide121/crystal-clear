const API_KEY = "HUBfBOYAY2krhsIhIpu7c0OgMgGPY3ru198GUXrXBy0";

export default async function getImages(input) {
  const url = `https://api.unsplash.com/search/photos?query=${input}&client_id=${API_KEY}`;

  const response = await fetch(url);
  const data = await response.json();
  const results = data.results;

  const randomIndex = Math.floor(Math.random() * 10);
  return results[randomIndex];
}
