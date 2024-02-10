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
  ngOnInit(): void{
    this.todoService.getAllTodos().subscribe({
      next: (todos: any) => {
        this.todos = todos;
      }
    });
  }
}
