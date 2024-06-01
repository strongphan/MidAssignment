import React from "react";
import { Navbar, Footer } from "./";
import { AppRoute } from "../route/AppRoute";

const Public = () => {
  return (
    <div>
      <div style={{ display: "flex" }}>
        <Navbar />

        <div className="PageContent">
          <AppRoute />
        </div>
      </div>

      <Footer />
    </div>
  );
};

export default Public;
