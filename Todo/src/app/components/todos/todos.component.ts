import { Component, OnInit, inject } from '@angular/core';
import { Todo } from 'src/app/models/todo.model';
import { Labels } from 'src/app/models/labels.model';
import { TodoService } from 'src/app/services/todo.service';
import { TodoLabels } from 'src/app/models/todolabels.model';
import {
  MatSnackBar,
  MatSnackBarRef,
  MatSnackBarModule,
  MatSnackBarConfig,
} from '@angular/material/snack-bar';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
  template: `
    <td>
      <button
        mat-stroked-button
        (click)="openCustomSnackBar('fsdf', 'sdf')"
        aria-label="Show an example snack-bar"
      >
        Pizza party
      </button>
    </td>
  `,
})
export class TodosComponent implements OnInit {
  todos: Todo[] = [];
  todolabels: TodoLabels[] = [];
  undoTodo: Todo = {
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

  displayedColumns: string[] = [
    'status',
    'title',
    'description',
    'completedTime',
    'labels',
    'actions',
  ];
  // private _snackBar: any;
  constructor(
    private todoService: TodoService,
    private _snackBar: MatSnackBar
  ) {}
  ngOnInit(): void {
    this.getAllTodos();
  }

  mainlabelarray: string[] = [];
  showlabelarray: string[] = [];
  showCompleteValue: boolean = true;
  temptodoLabels: TodoLabels[] = [];

  // openSnackBar() {
  //   this._snackBar.openFromComponent(PizzaPartyAnnotatedComponent, {
  //     duration: this.durationInSeconds * 1000,
  //   });
  // }

  getAllTodos() {
    this.todoService.getAllTodos().subscribe({
      next: (todolabels: TodoLabels[]) => {
        this.todolabels = todolabels;
        this.todolabels.forEach((todolabel) => {
          todolabel.labels.labelsarray = todolabel.todo.labels.split(',');
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
        this.temptodoLabels = todolabels; // this will take my array and store it for later usage
        if (this.showlabelarray.length > 0) {
          this.todolabels = this.temptodoLabels.filter((arg) =>
            arg.labels.mylabelsarray.some((label) =>
              this.showlabelarray.includes(label)
            )
          );
          console.log(this.todolabels);
        } else {
          this.todolabels = this.temptodoLabels;
        }

        if (this.showCompleteValue != true) {
          this.todolabels = this.todolabels.filter(
            (arg) => arg.todo.isCompleted == '1'
          );
        }

        if (this.mainlabelarray[0].length == 0) {
          this.mainlabelarray = this.mainlabelarray.filter(
            (element) => element !== ''
          );
        }
      },
      error: (error) => {
        console.error('Error retrieving todos:', error);
      },
    });
  }

  addTodo() {
    if (!this.newTodo.title || !this.newTodo.description) {
      alert('Please fill in all fields before submitting.');
      return; // Prevent form submission
    }
    if (this.newTodo.labels.length == 0) {
      this.newTodo.labels = 'daily,weekly,monthly';
    }
    console.log('Create TIme: ' + this.newTodo.createdTime);

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

  deleteTodo(id: number, todo: Todo) {
    this.undoTodo = todo;
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

    this.todoService.updateTodoCompletion(todo).subscribe({
      next: () => {
        this.getAllTodos();
      },
      error: (error) => {
        console.error('Error updating todo completion status:', error);
      },
    });
  }

  getShowCompleteStatus(arg: boolean): boolean {
    if (this.showCompleteValue == true) {
      this.todolabels = this.todolabels.filter(
        (arg) => arg.todo.isCompleted == '1'
      );
    } else {
      this.getAllTodos();
    }

    console.log('after pressing toggle: ' + this.todolabels);

    return (this.showCompleteValue = !arg);
  }

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
    if (this.showlabelarray.length > 0) {
      this.todolabels = this.temptodoLabels.filter((arg) =>
        arg.labels.mylabelsarray.some((label) =>
          this.showlabelarray.includes(label)
        )
      );
      console.log(this.todolabels);
    } else {
      this.todolabels = this.temptodoLabels;
    }
    if (this.showCompleteValue != true) {
      this.todolabels = this.todolabels.filter(
        (arg) => arg.todo.isCompleted == '1'
      );
    }
    // this.todolabels = this.todolabels.filter(arg => arg.todo)
    console.log('ShowLabelArray: ' + this.showlabelarray);
  }

  searchTerm: string = '';
  dueDateSearch: string = '';

  onSearch() {
    if (this.searchTerm.trim() !== '') {
      this.todolabels = this.temptodoLabels.filter((item) => {
        // Customize this logic based on your data structure
        return item.todo.title
          .toLowerCase()
          .includes(this.searchTerm.toLowerCase());
      });
    } else {
      this.todolabels = this.temptodoLabels; // Reset to original data if search term is empty
    }
  }

  onDueDateSearch() {
    const dateObject = new Date(this.dueDateSearch);
    const year = dateObject.getFullYear();
    const month = String(dateObject.getMonth() + 1).padStart(2, '0');
    const day = String(dateObject.getDate()).padStart(2, '0');
    const hour = String(dateObject.getHours()).padStart(2, '0');
    const minute = String(dateObject.getMinutes()).padStart(2, '0');
    const second = String(dateObject.getSeconds()).padStart(2, '0');
    const formattedDateString = `${month}/${day}/${year} ${hour}:${minute}:${second}`;
  }
  // durationInSeconds = 5;

  openSnackBar(message: string, action: string) {
    const config = new MatSnackBarConfig();
    config.duration = 2000; // Duration of the snack bar in milliseconds (default is 2750)
    config.horizontalPosition = 'center'; // Horizontal position of the snack bar ('start', 'center', 'end', 'left', 'right')
    config.verticalPosition = 'bottom'; // Vertical position of the snack bar ('top', 'bottom')
    config.panelClass = ['custom-snackbar-delete']; // Custom CSS class for styling the snack bar

    const snackBarRef = this._snackBar.open(message, action, config);
    snackBarRef.onAction().subscribe(() => {
      // Call your function when the action button is clicked
      // console.log("Snackbar is clicked");
      this.todoService.addTodo(this.undoTodo).subscribe({
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
    });
  }

  isExpired(updatedTime: string): boolean {
    const currentTime = new Date();
    const completionTime = new Date(updatedTime);
    return completionTime < currentTime;
  }

  getIsCompletedStatus(status: string): boolean {
    if (status == '1') {
      return true;
    }
    return false;
  }
}
