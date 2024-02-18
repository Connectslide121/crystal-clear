import axios from "axios";

export async function GetCities() {
  const response = await axios.get("api/cities").catch(function (error) {
    alert("Error fetching cities, there is no connection to the server");
    console.log("Error fetching cities:", error);
  });
  return response.data;
}

export async function CreateQuote(input) {
  const response = await axios
    .post("api/quotes/create", input)
    .catch(function (error) {
      alert("Error creating quote, there is no connection to the server");
      console.log("Error creating quote:", error);
    });
  return response.data;
}
