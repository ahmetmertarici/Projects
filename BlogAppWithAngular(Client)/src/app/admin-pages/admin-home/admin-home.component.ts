import { Component, OnInit } from '@angular/core';
import { Statistics } from 'src/app/models/statistics';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  constructor(private adminService:AdminService){}

  statistics!:Statistics;

  ngOnInit(): void {
    this.getStatistics();
  }

  getStatistics(): void {
    this.adminService.getStatistics().subscribe((data) => {
      this.statistics = data;
    });
  }

}
