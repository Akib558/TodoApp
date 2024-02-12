import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todos: Todo[] = [];
  // todos: any;

  constructor(private todoService: TodoService){

  }

  newTodo: Todo = {
    id: 0,
    title: "",
    description: ""
  };
  ngOnInit(): void{
    this.getAllTodos();
  }

  getAllTodos(){
    this.todoService.getAllTodos().subscribe({
      next: (todos: any) => {
        this.todos = todos;
      }
    });
  }

  addTodo() {
    this.todoService.addTodo(this.newTodo).subscribe({
      next: () => {
        this.getAllTodos();
        // Clear the form fields
        this.newTodo = {
          id: 0,
          title: '',
          description: ''
        };
      }
    });
  }


  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.getAllTodos();
      }
    });
  }

}
