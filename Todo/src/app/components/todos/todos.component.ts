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
  newTodo: Todo = {
    id: 0,
    title: "",
    description: "",
    createdTime: "",
    updatedTime: "",
    completedTime: "",
    isCompleted: "",
    labels: "",
    mylabels: ""
  };
// selectedLabel: any;

  labelarray: any[] = [];
  mylabelarray: any[] = [];

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.getAllTodos();
  }

  getAllTodos() {
    this.todoService.getAllTodos().subscribe({
      next: (todos: Todo[]) => {
        this.todos = todos;
        console.log(todos);

        // Clear the label array before populating it with new labels
        this.labelarray = [];

        // Iterate over each todo to extract labels
        todos.forEach(todo => {
          // Split the labels string into an array and push it into labelarray
          this.labelarray.push(todo.labels.split(','));
          this.mylabelarray.push(todo.mylabels.split(','));
        });

        console.log(this.labelarray);

      },
      error: (error) => {
        console.error('Error retrieving todos:', error);
      }
    });
  }


  addTodo() {
    if (!this.newTodo.title || !this.newTodo.description) {
      // Alert the user or handle the validation error as needed
      alert("Please fill in all fields before submitting.");
      return; // Prevent form submission
    }
    this.todoService.addTodo(this.newTodo).subscribe({
      next: (todo) => {
        this.getAllTodos();
        this.newTodo = {
          id: 0,
          title: "",
          description: "",
          createdTime: "",
          updatedTime: "",
          completedTime: "",
          isCompleted: "0",
          labels: "",
          mylabels: ""
        }; // Reset form
      },
      error: (error) => {
        console.error('Error adding todo:', error);
      }
    });
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.getAllTodos();
      },
      error: (error) => {
        console.error('Error deleting todo:', error);
      }
    });
  }
  getCheckboxValue(isCompletedString: string): boolean {
    return isCompletedString === "1" ? true : false;
  }

  toggleTodoCompletion(todo: Todo, isCompletedString: string) {
    // Toggle the completion status
    todo.isCompleted = isCompletedString == "0" ? "1" : "0";
    todo.mylabels = todo.mylabels ?? "";
    console.log(todo);

    // Update the completion status on the server
    this.todoService.updateTodoCompletion(todo).subscribe({
      next: () => {
        this.getAllTodos();
        // Optional: You can handle success response if needed
      },
      error: (error) => {
        console.error('Error updating todo completion status:', error);
        // Rollback the change if update fails
        // todo.isCompleted = todo.isCompleted === "0" ? "1" : "0";
      }
    });
  }
}
