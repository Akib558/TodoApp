// models/todo.model.ts

import { Labels } from "./labels.model";
import { Todo } from "./todo.model";

export interface TodoLabels {

  todo: Todo;
  labels: Labels;

}
