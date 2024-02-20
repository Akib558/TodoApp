import { Component } from '@angular/core';
import { RegistrationModel } from 'src/app/models/registration.model';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-register',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {



  constructor(private registrationService: RegistrationService){
  }

  reg: RegistrationModel = {
    username: '',
    password: '',
    email: ''
  }

  addUser() {
    console.log(this.reg);

    this.registrationService.addUser(this.reg).subscribe({
      next: (res) => {
        console.log(res);
        this.reg.email = '';
        this.reg.password = '';
        this.reg.username = '';
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

}
