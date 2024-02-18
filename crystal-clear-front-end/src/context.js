import { createContext } from "react";

export const QuoteContext = createContext({
  quote: "",
  setQuote: () => {}
});
