import { BehaviorSubject } from "rxjs";
import { Handover } from "./typescript-axios";

const _handover = new BehaviorSubject<Handover>({} as Handover);
const _handoverDate = new BehaviorSubject<Date>(new Date());

export const handoverService = {
  subject: _handover.asObservable(),
  send: function (msg: Handover) {
    _handover.next(msg);
  },
  get handoverValue() {
    return _handover.value;
  },
  dateSubject: _handoverDate.asObservable(),
  sendDate: function (msg: Date) {
    _handoverDate.next(msg);
  },
  get dateValue() {
    return _handoverDate.value;
  }
};
