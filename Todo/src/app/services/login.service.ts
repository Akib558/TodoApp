import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginModel } from "../models/login.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})

export class LoginService {
  // }

  baseApiUrl: string = "http://localhost:5202";
  constructor(private http: HttpClient) {}


  // getUser(usr: LoginModel) : Observable<LoginModel> {
  //   return this.http.get<LoginModel>(`${this.baseApiUrl}/api/todoall/register`, usr);
  // }
}
