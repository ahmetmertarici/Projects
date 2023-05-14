import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Comment } from 'src/app/models/comment';


@Component({
  selector: 'app-all-comments',
  templateUrl: './all-comments.component.html',
  styleUrls: ['./all-comments.component.css']
})
export class AllCommentsComponent implements OnInit {

  constructor(private adminService:AdminService){}
  comments!:Comment[];

  ngOnInit(): void {
    this.getAllComments();
  }

  getAllComments(): void {
    this.adminService.getAllComments().subscribe((data) => {
      this.comments=data;
      console.log(data);
    });

  }

}
