import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent {
  showMainLayout = true; // Varsayılan olarak göster

  constructor(private router: Router) {
    // Yönlendirmeleri dinle
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        // Eğer aktif URL '/adminlogin' ise, ana layout'u gösterme
        this.showMainLayout = !event.urlAfterRedirects.includes('adminlogin');
      }
    });
  }
}
