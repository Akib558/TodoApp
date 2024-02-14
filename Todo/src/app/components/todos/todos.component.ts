import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/todo.model';
import { Labels } from 'src/app/models/labels.model';
import { TodoService } from 'src/app/services/todo.service';
import { TodoLabels } from 'src/app/models/todolabels.model';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
})
export class TodosComponent implements OnInit {
  todos: Todo[] = [];
  todolabels: TodoLabels[] = [];
  newTodo: Todo = {
    id: 0,
    title: '',
    description: '',
    createdTime: '',
    updatedTime: '',
    completedTime: '',
    isCompleted: '',
    labels: '',
    myLabels: '',
  };
  // selectedLabel: any;

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.getAllTodos();
    // this.mainlabelarray = this.todolabels[0].labels.labelsarray;
  }

  mainlabelarray: string[] = [];

  showlabelarray: string[] = [];

  showCompleteValue: boolean = true;

  getShowCompleteStatus(arg: boolean): boolean {
    console.log(this.showCompleteValue);

    return (this.showCompleteValue = !arg);
  }
  // selectedLabels: { [key: string]: boolean } = {}; // Object to store selected labels
  isPresent(arg0: string[], arg1: string[]): boolean {
    if (arg1.length == 0) return true;
    return arg0.some((arg) => arg1.includes(arg));
  }
  onLabelSelected(label: string) {
    if (this.showlabelarray.includes(label)) {
      this.showlabelarray.splice(this.showlabelarray.indexOf(label), 1);
    } else {
      this.showlabelarray.push(label);
    }
    console.log(this.showlabelarray);
  }
  getAllTodos() {
    this.todoService.getAllTodos().subscribe({
      next: (todolabels: TodoLabels[]) => {
        this.todolabels = todolabels;
        const tempmainlabelarray = new Set();
        // Iterate over each TodoLabels object
        this.todolabels.forEach((todolabel) => {
          // Split the labels string into an array and assign it to labelsarray
          todolabel.labels.labelsarray = todolabel.todo.labels.split(',');
          console.log(todolabel.labels.labelsarray);

          // this.mainlabelarray = todolabel.labels.labelsarray;
          // Initialize and populate mylabelsarray
          todolabel.labels.mylabelsarray = [];
          if (todolabel.todo.myLabels) {
            const labelsArray = todolabel.todo.myLabels.split(',');
            if (labelsArray.length === 1 && labelsArray[0] === '') {
              todolabel.labels.mylabelsarray = [todolabel.todo.myLabels];
            } else {
              todolabel.labels.mylabelsarray = labelsArray;
            }
          }
          if (todolabel.labels.mylabelsarray.length !== 0) {
            if (this.mainlabelarray.length === 0) {
              this.mainlabelarray = Array.from(
                new Set(todolabel.labels.mylabelsarray)
              );
            } else {
              this.mainlabelarray = Array.from(
                new Set(
                  this.mainlabelarray.concat(todolabel.labels.mylabelsarray)
                )
              );
            }
          }
        });
        if (this.mainlabelarray[0].length == 0) {
          this.mainlabelarray.splice(0, 1);
        }
        console.log(this.mainlabelarray);
      },
      error: (error) => {
        console.error('Error retrieving todos:', error);
      },
    });
  }

  addTodo() {
    if (!this.newTodo.title || !this.newTodo.description) {
      // Alert the user or handle the validation error as needed
      alert('Please fill in all fields before submitting.');
      return; // Prevent form submission
    }
    if (this.newTodo.labels.length == 0) {
      this.newTodo.labels = 'daily,weekly,monthly';
    }
    this.todoService.addTodo(this.newTodo).subscribe({
      next: (todo) => {
        this.getAllTodos();
        this.newTodo = {
          id: 0,
          title: '',
          description: '',
          createdTime: '',
          updatedTime: '',
          completedTime: '',
          isCompleted: '0',
          labels: '',
          myLabels: '',
        }; // Reset form
      },
      error: (error) => {
        console.error('Error adding todo:', error);
      },
    });
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.getAllTodos();
      },
      error: (error) => {
        console.error('Error deleting todo:', error);
      },
    });
  }
  getCheckboxValue(isCompletedString: string): boolean {
    return isCompletedString === '1' ? true : false;
  }

  toggleTodoCompletion(todo: Todo, isCompletedString: string) {
    // Toggle the completion status
    todo.isCompleted = isCompletedString == '0' ? '1' : '0';
    todo.myLabels = todo.myLabels ?? '';
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
      },
    });
  }
}
