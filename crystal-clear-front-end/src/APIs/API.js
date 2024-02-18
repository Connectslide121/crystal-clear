import axios from "axios";

export async function GetCities() {
  const response = await axios.get("api/cities").catch(function (error) {
    alert("Error fetching cities, there is no connection to the server");
    console.log("Error fetching cities:", error);
  });
  return response.data;
}
