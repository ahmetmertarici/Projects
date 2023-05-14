import { Component, OnInit } from '@angular/core';
import { Statistics } from 'src/app/models/statistics';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
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
