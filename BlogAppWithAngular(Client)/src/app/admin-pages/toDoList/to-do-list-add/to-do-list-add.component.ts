import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TodolistService } from 'src/app/services/todolist.service';

@Component({
  selector: 'app-to-do-list-add',
  templateUrl: './to-do-list-add.component.html',
  styleUrls: ['./to-do-list-add.component.css']
})
export class ToDoListAddComponent {

  fileData: File | null = null;
  createTodoForm: FormGroup;
  constructor(private fb: FormBuilder, private todoService: TodolistService, private router: Router) {
    this.createTodoForm = this.fb.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
      comment: ['', Validators.required],
    });
  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  onSubmit(){
    if (this.createTodoForm.valid) {

      const formData = new FormData();
      formData.append('title', this.createTodoForm.get('title')?.value);
      formData.append('text', this.createTodoForm.get('text')?.value);
      formData.append('comment', this.createTodoForm.get('comment')?.value);

      this.todoService.createToDo(formData).subscribe(
        (result) => {
          console.log("eklendi");
          this.router.navigate(['/admin/yapilacaklar/liste']);
        },
        (error) => {
          console.error("Hata nesnesi:", error);
        }
      );
    }
  }

}
