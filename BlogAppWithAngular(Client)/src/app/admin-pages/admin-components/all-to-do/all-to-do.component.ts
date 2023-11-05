import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ToDoList } from 'src/app/models/to-do-list';
import { TodolistService } from 'src/app/services/todolist.service';

@Component({
  selector: 'app-all-to-do',
  templateUrl: './all-to-do.component.html',
  styleUrls: ['./all-to-do.component.css']
})
export class AllToDoComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private toDoService:TodolistService){}
  toDo!:ToDoList[];
  pagedToDo!: ToDoList[];
  toDoPerPage = 5;
  currentPage = 0;
  completedCount: number = 0; // Tamamlanmış görevlerin sayısı
  uncompletedCount: number = 0; // Tamamlanmamış görevlerin sayısı



  ngOnInit(): void {
    this.getAllToDo();
  }
  updateCompleted(toDo: ToDoList): void {
    console.log("toDo.id:", toDo.id);
    this.toDoService.updateCompleted(toDo).subscribe(
      () => {
        console.log('Güncelleme başarılı.');
      },
      (error) => {
        console.error('Güncelleme başarısız:', error);
      }
    );
  }

  getAllToDo(): void{
    this.toDoService.getAllToDo().subscribe((data)=>{
      this.toDo=data;
      this.completedCount = this.toDo.filter(t => t.completed).length;
      this.uncompletedCount = this.toDo.length - this.completedCount;
      this.updatePagedToDo();
    })
  }

  pageChanged(event: PageEvent): void {
    this.toDoPerPage = event.pageSize;
    this.currentPage = event.pageIndex;
    this.updatePagedToDo();
  }
  updatePagedToDo(): void {
    const startItem = this.currentPage * this.toDoPerPage;
    const endItem = startItem + this.toDoPerPage;
    this.pagedToDo = this.toDo.slice(startItem, endItem);
  }

}
