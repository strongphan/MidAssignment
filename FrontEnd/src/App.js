import "./styles/App.css";
import React from "react";
import { Public } from "./layouts";
import AuthProvider from "./context/authContext";

function App() {
  return (
    <AuthProvider>
      <div className="App">
        <Public />
      </div>
    </AuthProvider>
  );
}

export default App;
