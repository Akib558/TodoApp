import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Todo } from '../models/todo.model';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ResponseClass } from '../models/responseclass.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseApiUrl: string = "http://localhost:5202";

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<Todo[]> {
    return this.http.get<ResponseClass>(`${this.baseApiUrl}/api/todoall`).pipe(
      map(response => {
        if (response.status === 'Success') {
          return response.data as Todo[]; // Assuming Todo[] is your Todo model
        } else {
          throw new Error(response.message); // Throw an error if response status is not 'Success'
        }
      }),
      catchError(error => {
        throw error; // Rethrow any errors that occur during the request
      })
    );
  }

  addTodo(newTodo: Todo): Observable<Todo> {
    return this.http.post<ResponseClass>(`${this.baseApiUrl}/api/todoall`, newTodo).pipe(
      map(response => {
        if (response.status === 'Success') {
          return response.data as Todo; // Assuming Todo is your Todo model
        } else {
          throw new Error(response.message); // Throw an error if response status is not 'Success'
        }
      }),
      catchError(error => {
        throw error; // Rethrow any errors that occur during the request
      })
    );
  }

  // Adjust this method based on your API response
  deleteTodo(todoId: number): Observable<void> {
    return this.http.delete<ResponseClass>(`${this.baseApiUrl}/api/todoall/${todoId}`).pipe(
      map(response => {
        if (response.status === 'Success') {
          return; // Return void if the deletion was successful
        } else {
          throw new Error(response.message); // Throw an error if response status is not 'Success'
        }
      }),
      catchError(error => {
        throw error; // Rethrow any errors that occur during the request
      })
    );
  }
}
