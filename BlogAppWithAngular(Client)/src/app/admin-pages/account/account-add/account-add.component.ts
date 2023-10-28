import { Component } from '@angular/core';
import { RegisterModel } from 'src/app/models/register-model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-account-add',
  templateUrl: './account-add.component.html',
  styleUrls: ['./account-add.component.css']
})
export class AccountAddComponent {
  registerModel: RegisterModel = {
    FirstName: '',
    LastName: '',
    Email: '',
    UserName: '',
    Password: ''
  };


  constructor(private adminService: AdminService) {}

  register() {
    this.adminService.registerUser(this.registerModel).subscribe(
      res => {
        alert('Registration successful');
      },
      err => {
        alert('Registration failed');
      }
    );
  }
}
