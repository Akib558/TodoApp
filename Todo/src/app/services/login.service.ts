import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginModel } from "../models/login.model";
import { Observable } from "rxjs";
import { loginResponse } from "../models/loginResponse.model";

@Injectable({
  providedIn: 'root',
})

export class LoginService {
  // }

  baseApiUrl: string = "http://localhost:5202";
  constructor(private http: HttpClient) {}


  getUser(usr: LoginModel) : Observable<loginResponse> {
    return this.http.post<loginResponse>(`${this.baseApiUrl}/api/todoall/login`, usr);
  }
}
