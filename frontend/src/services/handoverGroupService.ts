import { BehaviorSubject } from "rxjs";
import { HandoverGroup } from "./typescript-axios";

const _handovergroup = new BehaviorSubject<HandoverGroup>({} as HandoverGroup);

export const handovergroupService = {
  subject: _handovergroup.asObservable(),
  send: function (msg: HandoverGroup) {
    _handovergroup.next(msg);
  },
  get groupValue() {
    return _handovergroup.value;
  }
};
