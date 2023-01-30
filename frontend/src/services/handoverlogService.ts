import { BehaviorSubject } from "rxjs";
import { HandoverLog } from "./typescript-axios";

const _handoverlog = new BehaviorSubject<HandoverLog>({} as HandoverLog);

export const handoverlogService = {
  subject: _handoverlog.asObservable(),
  send: function (msg: HandoverLog) {
    _handoverlog.next(msg);
  },
  get logValue() {
    return _handoverlog.value;
  }
};
