// auth.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class authService {
  static isLoggedIn(arg0: number) {
    throw new Error('Method not implemented.');
  }

  apiUrl: string = "http://localhost:5202";

  constructor(private http: HttpClient) { }



  logout(): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/auth`, {});
  }

  isLoggedIn(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/auth/${id}`, );
  }
}
