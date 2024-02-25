import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { LoginModel } from 'src/app/models/login.model';
import { loginResponse } from 'src/app/models/loginResponse.model';
import { LoginService } from 'src/app/services/login.service';
// import { authService } from 'src/app/services/auth.service';}

@Component({
  selector: 'app-register',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit  {
  // router: any;




  constructor(private loginService: LoginService, private router: Router){
  }

  usr: LoginModel = {
    username: '',
    password: '',
  }

  response: loginResponse = {
    status: '',
    data : {
      user_id: 0,
    },
    message: ''
  }


  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        if (event.url === '/login' || event.url === '/register') {
          if (LoginService.isLoggedIn(id) == 1) {
            this.router.navigateByUrl('/home');
          }
        }
      }
    });
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

    this.loginService.getUser(this.usr).subscribe({
      next: (response) => {
        console.log(response);
        if(response.status === 'Success') {
          this.response.status = response.status;
          this.response.data.user_id = response.data.user_id;
          this.response.message = response.message;
          this.router.navigate(['/']);
        }
        else{
          this.router.navigate(['login']);
        }


      },
      error: (err) => {
        console.log(err);
      }
    });
  }

}


