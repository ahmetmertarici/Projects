import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Article } from 'src/app/models/article';
import { MatPaginator } from '@angular/material/paginator';
import { AdminService } from 'src/app/services/admin.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

  displayedColumns: string[] = ['imageUrl', 'title', 'isApproved', 'createdDate', 'viewsCount', 'score', 'actions'];
  dataSource: any;
  articles: Article[] = [];
  imageUrl: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  deleteDialogTemplate: TemplateRef<any> | null = null;
  @ViewChild('deleteDialogTemplate') set deleteDialog(content: TemplateRef<any> | null) {
    this.deleteDialogTemplate = content;
  }

  constructor(private adminService: AdminService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getAllArticles();
  }

  getAllArticles(): void {
    this.adminService.getAllArticles().subscribe(data => {
      this.articles = data;
      this.dataSource = new MatTableDataSource<Article>(data);
      this.dataSource.paginator = this.paginator;
    });
  }

  onIsApprovedChange(articleId: number): void {
    this.adminService.updateIsApproved(articleId).subscribe(() => {
      this.getAllArticles();
    });
  }

  openDeleteConfirmation(articleId: number, title: string): void {
    const dialogRef = this.dialog.open(this.deleteDialogTemplate as TemplateRef<any>, {
      data: { message: `Makaleyi silmek istediğinize emin misiniz: ${title}?` }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'yes') {
        this.adminService.deleteArticle(articleId).subscribe(() => {
          this.getAllArticles();
        });
      }
    });
  }
}
