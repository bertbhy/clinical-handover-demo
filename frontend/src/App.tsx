import "jqwidgets-scripts/jqwidgets/styles/jqx.base.css";
import "jqwidgets-scripts/jqwidgets/styles/jqx.material.css";
import "jqwidgets-scripts/jqwidgets/styles/jqx.material-green.css";
import "react-datepicker/dist/react-datepicker.css";
import "./styles.css";

import React from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { NavBar } from "./components/NavBar";
import { ChakraProvider } from "@chakra-ui/react";
import theme from "./services/themeService";

import HomeContent from "./pages/HomeContent";

export const packageJson = require("../package.json");

export default function App() {
  document.title = "Handover";
  return (
    <ChakraProvider theme={theme}>
      <BrowserRouter basename={"/"}>
        <NavBar />
        <Routes>
          <Route path="/" element={<Navigate to="/home" replace={true} />} />
          <Route path="home" element={<HomeContent />}>
            <Route path=":patientKey" element={<HomeContent />} />
          </Route>
          <Route path="*" element={<Navigate to="/home" replace={true} />} />
        </Routes>
      </BrowserRouter>
    </ChakraProvider>
  );
}
