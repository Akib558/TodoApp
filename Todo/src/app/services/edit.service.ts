import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Todo } from '../models/todo.model';
import { Observable, catchError, map } from 'rxjs';
import { ResponseClass } from '../models/responseclass.model';

@Injectable({
  providedIn: 'root',
})
export class EditService {
  baseApiUrl: string = 'http://localhost:5202';
  constructor(private http: HttpClient) {}
  getTodoById(todoId: number): Observable<Todo> {
    // return this.http.get<Todo>(`${this.baseApiUrl}/api/todoall/${todoId}`);
    return this.http
      .get<ResponseClass>(`${this.baseApiUrl}/api/todoall/${todoId}`)
      .pipe(
        map((response) => {
          if (response.status === 'Success') {
            return response.data as Todo; // Assuming Todo[] is your Todo model
          } else {
            throw new Error(response.message); // Throw an error if response status is not 'Success'
          }
        }),
        catchError((error) => {
          throw error; // Rethrow any errors that occur during the request
        })
      );
  }

  updateTodo(todo: Todo): Observable<Todo> {
    return this.http.put<Todo>(
      `${this.baseApiUrl}/api/todoall/${todo.id}`,
      todo
    );
  }
}
