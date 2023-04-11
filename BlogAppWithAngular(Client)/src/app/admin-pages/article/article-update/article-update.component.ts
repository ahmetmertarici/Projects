import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { Category } from 'src/app/models/category';
import { AdminService } from 'src/app/services/admin.service';
import { ArticleService } from 'src/app/services/article.service';
import { CategoryService } from 'src/app/services/category.service';
import { MyvalidatorService } from 'src/app/services/myvalidator.service';

@Component({
  selector: 'app-article-update',
  templateUrl: './article-update.component.html',
  styleUrls: ['./article-update.component.css']
})
export class ArticleUpdateComponent implements OnInit {
  updateArticleForm: FormGroup;
  categories: Category[] | undefined;
  articleId: number;
  imageUrl!: string;
  fileData: File | null = null;
  image: string | null = null;

  public Editor = DecoupledEditor;
  onEditorReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  constructor(private fb: FormBuilder, private categoryService: CategoryService, private adminService: AdminService, private router: Router, public myValidation: MyvalidatorService, private activatedRoute: ActivatedRoute, private articleService: ArticleService) {
    this.updateArticleForm = this.fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required],
      categoryIds: ['', Validators.required],
      image: [null]
    });

    this.articleId = parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '0', 10);
  }

  async ngOnInit() {
    this.categories = await this.categoryService.getCategories().toPromise();
    const article = await this.adminService.getArticle(this.articleId).toPromise();
    if (article) {
      this.updateArticleForm.patchValue({
        title: article.title,
        content: article.content,
        categoryIds: article.categoryIds
      });
      this.imageUrl = article.imageUrl;
    }
    this.getCategory();
  }
  getCategory() {
    this.categoryService.getCategories().subscribe(result => {
      this.categories = result;
    })
  }

  upload(files: any) {
    this.fileData = files.target.files[0];
    let formData = new FormData();
    if (this.fileData) {
      formData.append("image", this.fileData);
    }

    this.adminService.saveArticlePicture(formData).subscribe(result => {
      console.log(result.path);
      this.image = result.path;

      this.updateArticleForm.controls['image'].setValue(this.image);

    });
  }

  async onSubmit() {
    if (this.updateArticleForm.valid) {
      const formData = new FormData();
      formData.append('title', this.updateArticleForm.get('title')?.value);
      formData.append('content', this.updateArticleForm.get('content')?.value);
      const categoryIds = this.updateArticleForm.get('categoryIds')?.value;
      for (let i = 0; i < categoryIds.length; i++) {
        formData.append(`categoryIds[${i}]`, categoryIds[i]);
      }

      if (this.fileData) {
        let imageFormData = new FormData();
        imageFormData.append("image", this.fileData);

        try {
          const imageResponse = await this.adminService.saveArticlePicture(imageFormData).toPromise();
          this.imageUrl = imageResponse.path;

          formData.append('imageUrl', this.imageUrl);
        } catch (error) {
          console.error('Error saving article image:', error);
        }
      }

      try {
        const response = await this.adminService.updateArticle(this.articleId, formData).toPromise();
        console.log('Article updated successfully:', response);
        this.router.navigate(['/admin/makale/liste']);
      } catch (error) {
        console.error('Error updating article:', error);
      }
    } else {
      console.log("Form is not valid");
    }
  }

}
