import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToDoList } from 'src/app/models/to-do-list';
import { TodolistService } from 'src/app/services/todolist.service';

@Component({
  selector: 'app-to-do-list-list',
  templateUrl: './to-do-list-list.component.html',
  styleUrls: ['./to-do-list-list.component.css']
})
export class ToDoListListComponent implements OnInit {
  displayedColumns: string[] = ['title', 'text',  'completed', 'actions'];
  dataSource: any;
  toDos: ToDoList[] = [];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  deleteDialogTemplate: TemplateRef<any> | null = null;
  @ViewChild('deleteDialogTemplate') set deleteDialog(content: TemplateRef<any> | null) {
    this.deleteDialogTemplate = content;
  }

  constructor(private toDoService: TodolistService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getAllToDo();
  }

  getAllToDo(): void{
    this.toDoService.getAllToDo().subscribe((data)=>{
      this.toDos=data;
      this.dataSource = new MatTableDataSource<ToDoList>(data);
      this.dataSource.paginator = this.paginator;
    });
  }

  onIsApprovedChange(id: number): void {
    // this.toDoService.updateIsApproved(articleId).subscribe(() => {
    //   this.getAllToDo();
    // });
  }

  openDeleteConfirmation(id: number, title: string): void {
    const dialogRef = this.dialog.open(this.deleteDialogTemplate as TemplateRef<any>, {
      data: { message: `Makaleyi silmek istediğinize emin misiniz: ${title}?` }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'yes') {
        this.toDoService.deleteTodo(id).subscribe(() => {
          this.getAllToDo();
        });
      }
    });
  }
}
