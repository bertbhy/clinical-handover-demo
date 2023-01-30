import { handoverService } from "./handoverService";
import { BehaviorSubject } from "rxjs";
import { GetWardPatient, Handover, HandoverLog } from "./typescript-axios";
import { handoverlogService } from "./handoverlogService";

const _GetWardPatient = new BehaviorSubject<GetWardPatient>(
  {} as GetWardPatient
);

export const getPatientService = {
  subject: _GetWardPatient.asObservable(),
  send: function (msg: GetWardPatient) {
    if (msg?.patientKey) document.title = "Handover - " + msg?.patientKey;
    else document.title = "Handover";
    handoverService.send({} as Handover);
    handoverlogService.send({} as HandoverLog);
    _GetWardPatient.next(msg);
  },
  resend: () => {
    _GetWardPatient.next(_GetWardPatient.value);
  },
  get patientValue() {
    return _GetWardPatient.value;
  }
};
