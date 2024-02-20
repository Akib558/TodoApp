import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodosComponent } from './components/todos/todos.component';
import { EditComponent } from './components/edit/edit.component';
import { RegistrationComponent } from './navbar/register/registration.component';

const routes: Routes = [
  {
    path: '',
    component: TodosComponent
  },
  {
    path: 'register', component: RegistrationComponent
  },
  {
    path: 'todos',
    component: TodosComponent
  },
  { path: 'edit/:id', component: EditComponent }, // Route for editing page with a parameter (id)
  { path: '**', redirectTo: '/todos' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
