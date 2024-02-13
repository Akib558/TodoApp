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
  cdr: any;
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
      next: (todo) => {
        // console.log('New todo added:', todo);
        // console.log("Correct todo added");
        this.getAllTodos();
        // this.todos.push(todo); // Add the new todo to the list
        this.newTodo = { id: 0, title: "", description: "" }; // Clear the form fields

        // this.cdr.detectChanges(); // Manually trigger change detection
      },
      error: (error) => {
        console.error('Error adding todo:', error);
        // console.log(this.todos);
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
