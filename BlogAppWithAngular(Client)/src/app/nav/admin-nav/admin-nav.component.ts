import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-admin-nav',
  templateUrl: './admin-nav.component.html',
  styleUrls: ['./admin-nav.component.css']
})
export class AdminNavComponent {
  constructor(private authService: AuthenticationService, private router: Router) {}

  onLogout() {
    this.authService.logout().subscribe(() => {
      // Yönlendirme veya herhangi bir işlem yapabilirsiniz.
      // this.router.navigate(['/adminlogin']);
    });
  }
}
