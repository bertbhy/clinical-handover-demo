import { render } from "react-dom";
import App from "./App";

window.process = {} as any;

let ieloading = document.getElementById("ieloading");
ieloading?.remove();

const rootElement = document.getElementById("root");
render(<App />, rootElement);
