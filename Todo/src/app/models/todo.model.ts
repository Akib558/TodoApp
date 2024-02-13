// models/todo.model.ts

export interface Todo {
  id: number;
  title: string;
  description: string;
  createdTime?: string; // Optional as it is not included in the response
  updatedTime?: string; // Optional as it is not included in the response
  completedTime: string;
  isCompleted: string;

}
