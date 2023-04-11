import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { AdminLayoutComponent } from 'src/app/layout/admin-layout/admin-layout.component';
import { AdminNavComponent } from 'src/app/nav/admin-nav/admin-nav.component';
import { AdminArticleComponent } from './article/article/article.component';
import { ArticleAddComponent } from './article/article-add/article-add.component';
import { ArticleUpdateComponent } from './article/article-update/article-update.component';
import { ArticleListComponent } from './article/article-list/article-list.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CategoryComponent } from './category/category/category.component';
import { CategoryAddComponent } from './category/category-add/category-add.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryUpdateComponent } from './category/category-update/category-update.component';

@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminNavComponent,
    AdminArticleComponent,
    ArticleAddComponent,
    ArticleUpdateComponent,
    ArticleListComponent,
    CategoryComponent,
    CategoryAddComponent,
    CategoryListComponent,
    CategoryUpdateComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MaterialModule,
    ComponentsModule,
    MatPaginatorModule,
    CKEditorModule
  ]
})
export class AdminModule { }
