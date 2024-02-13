import { Todo } from 'src/app/models/todo.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { Todo } from '../models/todo.model';
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
          const todos = Array.isArray(response.data) ? response.data : [response.data];
          return todos.map(todo => ({
            id: todo.id,
            title: todo.title,
            description: todo.description,
            createdTime: todo.createdTime,
            updatedTime: todo.updatedTime,
            completedTime: todo.completedTime,
            isCompleted: todo.isCompleted
          }));
        } else {
          throw new Error(response.message);
        }
      }),
      catchError(error => {
        throw error;
      })
    );
  }

  addTodo(newTodo: Todo): Observable<Todo> {
    return this.http.post<ResponseClass>(`${this.baseApiUrl}/api/todoall`, newTodo).pipe(
      map(response => {
        if (response.status === 'Success') {
          const todo = response.data;
          return {
            id: todo.id,
            title: todo.title,
            description: todo.description,
            createdTime: todo.createdTime,
            updatedTime: todo.updatedTime,
            completedTime: todo.completedTime,
            isCompleted: todo.isCompleted
          };
        } else {
          throw new Error(response.message);
        }
      }),
      catchError(error => {
        throw error;
      })
    );
  }

  updateTodoCompletion(todo: Todo): Observable<Todo> {
    // const updatedTodo = {
    //   id: todo.id,
    //   title: todo.title,
    //   description: todo.description,
    //   createdTime: todo.createdTime,
    //   updatedTime: todo.updatedTime,
    //   completedTime: todo.completedTime,
    //   isCompleted: todo.isCompleted
    // }; // Construct the updated todo object with the new completion status
    todo.isCompleted = todo.isCompleted == "0" ? "0" : "1";
    console.log("updateTodoCompletion", todo);

    return this.http.put<ResponseClass>(`${this.baseApiUrl}/api/todoall/${todo.id}`, todo).pipe(
      map(response => {
        // console.log(response);
        // const todo = response.data;
        // console.log("response is: " + todo);


        if (response.status === 'Success') {
          const todo = response.data;
          return {
            id: todo.id,
            title: todo.title,
            description: todo.description,
            createdTime: todo.createdTime,
            updatedTime: todo.updatedTime,
            completedTime: todo.completedTime,
            isCompleted: todo.isCompleted
          };
          // return ; // Return void if the update was successful
        } else {
          throw new Error(response.message);
        }
      }),
      catchError(error => {
        console.log("Did not receive error: " + error);

        throw error;
      })
    );
  }


  deleteTodo(todoId: number): Observable<void> {
    return this.http.delete<ResponseClass>(`${this.baseApiUrl}/api/todoall/${todoId}`).pipe(
      map(response => {
        if (response.status === 'Success') {
          return;
        } else {
          throw new Error(response.message);
        }
      }),
      catchError(error => {
        throw error;
      })
    );
  }

  // You may implement updateTodoCompletion method similarly
}


