import { AccountApi, HandoverApi, PmiApi } from "./typescript-axios";
import { parseISO } from "date-fns";
import axios from "axios";

const isoDateTimeFormat =
  /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d*)?(?:[-+]\d{2}:?\d{2}|Z)?$/;
const isoDateFormat = /^\d{4}-\d{2}-\d{2}?$/;

function isIsoDateString(value: any): boolean {
  return (
    value &&
    typeof value === "string" &&
    (isoDateFormat.test(value) || isoDateTimeFormat.test(value))
  );
}

function handleDates(body: any) {
  if (body === null || body === undefined || typeof body !== "object")
    return body;

  for (const key of Object.keys(body)) {
    const value = body[key];
    if (isIsoDateString(value)) {
      body[key] = parseISO(value);
    } else if (typeof value === "object") handleDates(value);
  }
}

const client = axios.create();

client.interceptors.response.use((originalResponse) => {
  handleDates(originalResponse.data);
  return originalResponse;
});

const handover = new HandoverApi(undefined, process.env.REACT_APP_API, client);
const account = new AccountApi(undefined, process.env.REACT_APP_API, client);
const pmi = new PmiApi(undefined, process.env.REACT_APP_API, client);

export const apiService = {
  handover: handover,
  account: account,
  pmi: pmi
};
