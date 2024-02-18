import React from "react";
import ReactDOM from "react-dom/client";
import "./styles.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ErrorComponent from "./components/ErrorComponent";
import Header from "./components/Header";

import QuoteForm from "./components/QuoteForm";
import { QuoteFormLoader, QuoteFormAction } from "./components/QuoteForm";

import Quote, { QuoteLoader } from "./components/Quote";

const router = createBrowserRouter([
  {
    element: <Header />,
    errorElement: <ErrorComponent />,
    children: [
      {
        path: "/",
        element: <QuoteForm />,
        errorElement: <ErrorComponent />,
        loader: QuoteFormLoader,
        action: QuoteFormAction
      },
      {
        path: "/quote/:quote",
        element: <Quote />,
        errorElement: <ErrorComponent />,
        loader: QuoteLoader
      }
    ]
  }
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
