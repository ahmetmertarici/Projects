import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Category } from 'src/app/models/category';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: Category[]=[];
  displayedColumns = ['id', 'name', 'actions'];

  deleteDialogTemplate: TemplateRef<any> | null = null;
  @ViewChild('deleteDialogTemplate') set deleteDialog(content: TemplateRef<any> | null) {
    this.deleteDialogTemplate = content;
  }

  constructor(private adminService:AdminService, private dialog: MatDialog){}

  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories(){
    this.adminService.getAllCategories().subscribe(data=>{
      this.categories=data;
    })
  }

  openDeleteConfirmation(categoryId: number, categoryName: string): void {
    const dialogRef = this.dialog.open(this.deleteDialogTemplate as TemplateRef<any>, {
      data: { message: `Kategoriyi silmek istediğinize emin misiniz: ${categoryName}?` }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'yes') {
        this.adminService.deleteCategory(categoryId).subscribe(() => {
          this.getAllCategories();
        });
      }
    });
  }

}
