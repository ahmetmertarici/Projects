import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { Category } from 'src/app/models/category';
import { AdminService } from 'src/app/services/admin.service';
import { CategoryService } from 'src/app/services/category.service';
import { MyvalidatorService } from 'src/app/services/myvalidator.service';
import { arrayRequiredValidator } from 'src/app/shared/validators/array-required.validator';

@Component({
  selector: 'app-article-add',
  templateUrl: './article-add.component.html',
  styleUrls: ['./article-add.component.css']

})
export class ArticleAddComponent implements OnInit {
  fileData: File | null = null;
  image: string | null = null;
  success!: boolean;
  loading!: boolean;
  info!: string;
  createArticleForm: FormGroup;
  categories: Category[] | undefined;

  public Editor = DecoupledEditor;
  onEditorReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  constructor(private fb: FormBuilder, private categoryService: CategoryService, private adminService: AdminService, private router: Router, public myValidation: MyvalidatorService) {
    this.createArticleForm = this.fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required],
      categoryIds: ['', arrayRequiredValidator()],
      image: [null]
    });

    this.createArticleForm.valueChanges.subscribe(value => {
      console.log('Form value:', value);
    });

    this.createArticleForm.statusChanges.subscribe(status => {
      console.log('Form status:', status);
    });

  }

  async ngOnInit() {
    this.getCategory();
  }

  //*********************************** */
  upload(files: any) {
    this.fileData = files.target.files[0];
    let formData = new FormData();
    if (this.fileData) {
      formData.append("image", this.fileData);
    }

    this.adminService.saveArticlePicture(formData).subscribe(result => {
      console.log(result.path);
      this.image = result.path;

      this.createArticleForm.controls['image'].setValue(this.image);

    });
  }
  //**************************************** */
  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.createArticleForm.patchValue({
        image: file
      });
    }
  }
  getCategory() {
    this.categoryService.getCategories().subscribe(result => {
      this.categories = result;
    })
  }
  onSubmit() {
    if (this.createArticleForm.valid) {
      this.loading = true;

      const formData = new FormData();
      formData.append('title', this.createArticleForm.get('title')?.value);
      formData.append('content', this.createArticleForm.get('content')?.value);
      formData.append('image', this.createArticleForm.get('image')?.value);
      formData.append('imageUrl', this.image as string);

      const categoryIds = this.createArticleForm.get('categoryIds')?.value;
      for (const categoryId of categoryIds) {
        formData.append('categoryIds', categoryId);
      }

      this.adminService.createArticle(formData).subscribe(
        (result) => {
          console.log("eklendi");
          this.router.navigate(['/admin/makale/liste']);
        },
        (error) => {
          console.error("Hata nesnesi:", error);
          this.success = false;
          this.info = "hata:" + error;
        }
      );
    }
  }


}
