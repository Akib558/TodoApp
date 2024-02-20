import { Component } from '@angular/core';
import { LoginModel } from 'src/app/models/login.model';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-register',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {



  constructor(private loginService: LoginService){
  }

  usr: LoginModel = {
    username: '',
    password: '',
  }

  addUser() {
    // console.log(this.usr);

    // this.loginService.getUser(this.usr).subscribe({
    //   next: (res) => {
    //     console.log(res);
    //   },
    //   error: (err) => {
    //     console.log(err);
    //   }
    // })

    // this.loginService.getUser(this.usr).subscribe({
    //   next: (usr) => {
    //     console.log(usr);
    //     // this.usr.email = '';
    //     this.usr.password = '';
    //     this.usr.username = '';
    //   },
    //   error: (err) => {
    //     console.log(err);
    //   }
    // });
  }

}
