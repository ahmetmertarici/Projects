import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent{
  email = '';
  password = '';
  rememberMe = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  login() {
    this.authService.login(this.email, this.password, this.rememberMe).subscribe(
      () => {
        this.router.navigate(['/admin']);
      },
      (error) => {
        console.log('API Error: ', error);
        alert('Kullanıcı adı yada şifre hatalı:');
      }
    );
  }
}
