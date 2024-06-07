import "./styles/App.css";
import React from "react";
import { Public } from "./layouts";
import AuthProvider from "./context/authContext";
import CartContextProvider from "./context/cartContext";

function App() {
  return (
    <AuthProvider>
      <CartContextProvider>
        <div className="App">
          <Public />
        </div>
      </CartContextProvider>
    </AuthProvider>
  );
}

export default App;
