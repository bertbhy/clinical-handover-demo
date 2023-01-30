import { HandoverGroup } from './typescript-axios/models/handover-group';
import { handovergroupService } from './handoverGroupService';
import { GetWardPatient, LoginResponse } from "../services/typescript-axios";
import { BehaviorSubject } from "rxjs";

import { LoginRequest } from "../services/typescript-axios";
import { apiService } from "./axiosService";
import { createStandaloneToast } from "@chakra-ui/react";
import { getPatientService } from "./getPatientService";

const userSubject = new BehaviorSubject<LoginResponse>(
  JSON.parse((localStorage ? localStorage.getItem("user_json") : "") as string) as LoginResponse
);

export const userService = {
  user: userSubject.asObservable(),
  get userValue() {
    return userSubject.value;
  },
  login,
  logout
};

function login(model: LoginRequest) {
  let api = apiService.account;

  return api
    .accountLogin(model, { withCredentials: true })
    .then((user) => {
      // publish user to subscribers and store in local storage to stay logged in between page refreshes
      userSubject.next(user.data);
      localStorage && localStorage.setItem("user_json", JSON.stringify(user.data));
      return user;
    })
    .catch((err) => {});
}

function logout() {
  localStorage && localStorage.clear();

  let api = apiService.account;
  api
    .accountLogout({ withCredentials: true })
    .then(() => {
      userSubject.next({} as LoginResponse);
      handovergroupService.send({} as HandoverGroup);
      getPatientService.send({} as GetWardPatient);
    })
    .catch((err) => {
      const toast = createStandaloneToast();
      toast({
        title: `Server not found`,
        description: ``,
        status: "error",
        duration: 9000,
        isClosable: true,
        position: "bottom-right"
      });
    });
}
