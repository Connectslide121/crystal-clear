import React from "react";
import logo from "../images/logo.webp";
import { Outlet } from "react-router-dom";

export default function Header() {
  return (
    <div id="app">
      <section id="hero">
        <img src={logo} alt="logo" className="logo" />
      </section>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
