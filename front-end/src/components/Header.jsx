import React from "react";
import logo from "../images/logo.png";
import { Outlet } from "react-router-dom";

export default function Header() {
  return (
    <>
      <section id="hero">
        <img src={logo} alt="logo" className="logo" />
      </section>
      <main>
        <Outlet />
      </main>
    </>
  );
}
