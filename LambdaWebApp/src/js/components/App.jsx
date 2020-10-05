import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";

export default function App(params) {
  return <>hello world</>;
}

const wrapper = document.getElementById("root");
wrapper ? ReactDOM.render(<App />, wrapper) : false;
