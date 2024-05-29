import React from "react";
import { Navbar, Footer } from "./";
import { AppRoute } from "../route/AppRoute";

const Public = () => {
  return (
    <div>
      <Navbar />

      <div className="PageContent">
        <AppRoute />
      </div>

      <Footer />
    </div>
  );
};

export default Public;
