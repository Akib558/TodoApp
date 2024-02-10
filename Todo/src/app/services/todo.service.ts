import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Todo } from '../models/todo.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseApiUrl: string = "http://localhost:5202"; 
  constructor(private http: HttpClient) { }
  getAllTodos(): Observable<Todo[]> {
    // return this.http.get<Todo[]>("https://run.mocky.io/v3/39a86313-5096-40c2-84e2-7acc225cc75a");

    return this.http.get<Todo[]>(this.baseApiUrl+"/api/todoall");
  }
}
