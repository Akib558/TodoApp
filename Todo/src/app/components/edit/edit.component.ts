import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import ActivatedRoute and Router
import { Todo } from 'src/app/models/todo.model';
import { EditService } from 'src/app/services/edit.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  newTodo: Todo = {
    id: 0,
          title: "",
          description: "",
          createdTime: "",
          updatedTime: "",
          completedTime: "",
          isCompleted: "0",
  };

  constructor(
    private editService: EditService,
    private route: ActivatedRoute, // Inject ActivatedRoute
    private router: Router // Inject Router
  ) {}

  ngOnInit(): void {
    // Extract the todo ID from the URL
    const todoId = this.route.snapshot.params['id']; // Assuming the route parameter is named 'id'
    this.getTodoById(todoId); // Call getTodoById with the extracted ID
  }

  getTodoById(id: number): void {
    this.editService.getTodoById(id).subscribe({
      next: (todo: Todo) => {
        this.newTodo = todo; // Populate newTodo object with fetched todo data
      },
      error: (error) => {
        console.error('There was an error fetching the todo:', error);
      }
    });
  }
  getCheckboxValue(isCompletedString: string): boolean {
    return isCompletedString === "1" ? true : false;
  }

  toggleTodoCompletion(todo: Todo, isCompletedString: string) {
    todo.isCompleted = isCompletedString == "0" ? "1" : "0";
  }
  updateTodo(): void {
    this.editService.updateTodo(this.newTodo).subscribe({
      next: (updatedTodo: Todo) => {
        console.log('Todo updated successfully:', updatedTodo);
        // Navigate to the home page after updating the todo
        this.router.navigate(['/']); // Navigate to the home page
      },
      error: (error) => {
        console.error('Error updating todo:', error);
        // Optionally, you can show an error message here
      }
    });
  }
}
