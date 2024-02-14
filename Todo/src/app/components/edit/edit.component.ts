import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import ActivatedRoute and Router
import { Todo } from 'src/app/models/todo.model';
import { TodoLabels } from 'src/app/models/todolabels.model';
import { EditService } from 'src/app/services/edit.service';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
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

  constructor(
    private editService: EditService,
    private route: ActivatedRoute,
    private router: Router,
    private todoService: TodoService
  ) {}

  ngOnInit(): void {
    const todoId = this.route.snapshot.params['id'];
    this.getAllTodos();
    this.getTodoById(todoId);

  }

  labelText: string = '';
  mainlabelarray: string[] = this.newTodo.labels.split(',');
  showlabelarray: string[] = this.newTodo.myLabels.split(',');

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

        this.todolabels.forEach((todolabel) => {

          todolabel.labels.labelsarray = todolabel.todo.labels.split(',');
          console.log(todolabel.labels.labelsarray);

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

  getTodoById(id: number): void {
    this.editService.getTodoById(id).subscribe({
      next: (todo: Todo) => {
        this.newTodo = todo;


        this.showlabelarray = this.newTodo.myLabels.split(',');
      },
      error: (error) => {
        console.error('There was an error fetching the todo:', error);
      },
    });
  }
  getCheckboxValue(isCompletedString: string): boolean {
    return isCompletedString === '1' ? true : false;
  }

  toggleTodoCompletion(todo: Todo, isCompletedString: string) {
    todo.isCompleted = isCompletedString == '0' ? '1' : '0';
  }
  updateTodo(): void {
    if (this.labelText.length > 0) {
      this.showlabelarray.push(this.labelText);
    }
    this.newTodo.myLabels = this.showlabelarray.join(',');
    this.editService.updateTodo(this.newTodo).subscribe({
      next: (updatedTodo: Todo) => {
        console.log('Todo updated successfully:', updatedTodo);

        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error('Error updating todo:', error);

      },
    });
  }
}
