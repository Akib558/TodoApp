import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RegistrationModel } from "../models/registration.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})

export class RegistrationService {
  baseApiUrl: string = "http://localhost:5202";
  constructor(private http: HttpClient) {}


  addUser(reg: RegistrationModel) : Observable<RegistrationModel> {
    return this.http.post<RegistrationModel>(`${this.baseApiUrl}/api/todoall/register`, reg);
  }
}
