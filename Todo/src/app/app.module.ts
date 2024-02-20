import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodosComponent } from './components/todos/todos.component';
import { FormsModule } from '@angular/forms';
import { EditComponent } from './components/edit/edit.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AppModuleModule } from './app-module/app-module.module';
import { NavbarComponent } from './navbar/navbar.component';
import { RegistrationComponent } from './navbar/register/registration.component';
import { LoginComponent } from './navbar/login/login.component';
// import { RegisterComponent } from './navbar/register/register.component';
@NgModule({
  declarations: [
    AppComponent,
    TodosComponent,
    EditComponent,
    NavbarComponent,
    RegistrationComponent,
    LoginComponent
    // RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    // MatSlideToggleModule,
    AppModuleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
