import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { AdminService } from 'src/app/services/admin.service';
import { CategoryService } from 'src/app/services/category.service';
import { MyvalidatorService } from 'src/app/services/myvalidator.service';

@Component({
  selector: 'app-article-add',
  templateUrl: './article-add.component.html',
  styleUrls: ['./article-add.component.css']

})
export class ArticleAddComponent implements OnInit {
  createArticleForm: FormGroup;
  categories: Category[] | undefined;

  constructor(private fb: FormBuilder, private categoryService: CategoryService, private adminService: AdminService, private router: Router, public myValidation:MyvalidatorService) {
    this.createArticleForm = this.fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required],
      categoryIds: ['', Validators.required],
      image: [null]
    });
  }

  async ngOnInit() {
    this.categories = await this.categoryService.getCategories().toPromise();
  }
  GetValidationMessages(f: AbstractControl, name: string) {
    if (f.errors) {
      for (let errroName in f.errors) {
        if (errroName == "required") return `${name} alanı boş bırakılamaz`;
        else if (errroName == "email") return `email formatı yanlış`;
        else if (errroName == "minlength")
          return `${name} alanız en az 5 karakter olmalıdır.`;
      }
    }
    return null;
  }

  get getControls() {
    return this.createArticleForm.controls;
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.createArticleForm.patchValue({
        image: file
      });
    }
  }

  

  async onSubmit() {
    if (this.createArticleForm.valid) {

      const formData = new FormData();
      formData.append('title', this.createArticleForm.get('title')?.value);
      formData.append('content', this.createArticleForm.get('content')?.value);
      const categoryIds = this.createArticleForm.get('categoryIds')?.value;
      for (let i = 0; i < categoryIds.length; i++) {
        formData.append(`categoryIds[${i}]`, categoryIds[i]);
      }


      if (this.createArticleForm.get('image')?.value) {
        formData.append('image', this.createArticleForm.get('image')?.value);
      }

      try {
        const response = await this.adminService.createArticle(formData).toPromise();
        console.log('Article created successfully:', response);
        this.router.navigate(['/admin/makale/liste']);
      } catch (error) {
        console.error('Error creating article:', error);
      }
    }
  }
}
