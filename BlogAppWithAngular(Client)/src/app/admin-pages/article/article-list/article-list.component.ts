import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Article } from 'src/app/models/article';
import {MatPaginator} from '@angular/material/paginator';
import { ArticleService } from 'src/app/services/article.service';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

  displayedColumns: string[] = ['imageUrl', 'title', 'isApproved', 'createdDate', 'viewsCount', 'score'];
  dataSource:any;
  articles:Article[]=[];
  imageUrl: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private adminService:AdminService){}
  ngOnInit(): void {
    this.adminService.getAllArticles().subscribe(data=>{
      this.articles=data;
      this.dataSource= new MatTableDataSource<Article>(data);
      this.dataSource.paginator=this.paginator;

    });
  }




}
