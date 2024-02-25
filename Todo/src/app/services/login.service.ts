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

  logout(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}/api/auth/${id}`).pipe((response) => {
      return response;
    });
  }

  isLoggedIn(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseApiUrl}/api/auth/${id}`).pipe((response) => {
      return response;
    });
  }
  getUser(usr: LoginModel) : Observable<loginResponse> {
    return this.http.post<loginResponse>(`${this.baseApiUrl}/api/todoall/login`, usr);
  }
}
