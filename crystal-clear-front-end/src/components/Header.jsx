import React, { useState } from "react";
import logo from "../images/logo.webp";
import { Outlet } from "react-router-dom";
import { QuoteContext } from "../context";

export default function Header() {
  const [quote, setQuote] = useState({});

  return (
    <div id="app">
      <section id="hero">
        <img src={logo} alt="logo" className="logo" />
      </section>
      <main>
        <QuoteContext.Provider value={{ quote, setQuote }}>
          <Outlet />
        </QuoteContext.Provider>
      </main>
    </div>
  );
}
