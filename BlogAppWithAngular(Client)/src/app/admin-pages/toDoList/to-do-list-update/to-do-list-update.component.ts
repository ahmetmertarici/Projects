import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TodolistService } from 'src/app/services/todolist.service';

@Component({
  selector: 'app-to-do-list-update',
  templateUrl: './to-do-list-update.component.html',
  styleUrls: ['./to-do-list-update.component.css']
})
export class ToDoListUpdateComponent {
  updateTodoForm: FormGroup;
  id:number;


  constructor(private fb: FormBuilder, private todoService: TodolistService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.updateTodoForm = this.fb.group({
      text: [''],
      title: [''],
      comment: ['']
    });
    this.id = parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '0', 10);
  }



  async ngOnInit() {
    const toDo =await this.todoService.getTodo(this.id).toPromise();
    if (toDo) {
      this.updateTodoForm.patchValue({
        text: toDo.text,
        title:toDo.title,
        comment:toDo.comment
      });
    }
  }


  onSubmit(){
    if (this.updateTodoForm.valid) {

      const formData = new FormData();
      formData.append('text', this.updateTodoForm.get('text')?.value);
      formData.append('title', this.updateTodoForm.get('title')?.value);
      formData.append('comment', this.updateTodoForm.get('comment')?.value);

      this.todoService.updateTodo(this.id, formData).subscribe(
        (result) => {
          console.log("eklendi");
          this.router.navigate(['/admin/hakkimda-düzenle/liste']);
        },
        (error) => {
          console.error("Hata nesnesi:", error);
        }
      );
    }
  }
}
