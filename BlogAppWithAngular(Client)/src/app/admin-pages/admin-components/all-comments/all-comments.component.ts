import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Comment } from 'src/app/models/comment';
import { MatPaginator, PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-all-comments',
  templateUrl: './all-comments.component.html',
  styleUrls: ['./all-comments.component.css']
})
export class AllCommentsComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private adminService:AdminService){}
  comments!:Comment[];
  pagedComments!: Comment[];
  commentsPerPage = 5;
  currentPage = 0;

  ngOnInit(): void {
    this.getAllComments();
  }

  getAllComments(): void {
    this.adminService.getAllComments().subscribe((data) => {
      this.comments=data;
      this.updatePagedComments();
    });

  }

  pageChanged(event: PageEvent): void {
    this.commentsPerPage = event.pageSize;
    this.currentPage = event.pageIndex;
    this.updatePagedComments();
  }
  updatePagedComments(): void {
    const startItem = this.currentPage * this.commentsPerPage;
    const endItem = startItem + this.commentsPerPage;
    this.pagedComments = this.comments.slice(startItem, endItem);
  }

}
