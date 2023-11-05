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
import { AdminAboutMeComponent } from './about-me/admin-about-me/admin-about-me.component';
import { AboutMeAddComponent } from './about-me/about-me-add/about-me-add.component';
import { AboutMeListComponent } from './about-me/about-me-list/about-me-list.component';
import { AboutMeUpdateComponent } from './about-me/about-me-update/about-me-update.component';
import { StatisticsComponent } from './admin-components/statistics/statistics.component';
import { AllCommentsComponent } from './admin-components/all-comments/all-comments.component';
import { AccountComponent } from './account/account/account.component';
import { AccountAddComponent } from './account/account-add/account-add.component';
import { ToDoListListComponent } from './toDoList/to-do-list-list/to-do-list-list.component';
import { ToDoListAddComponent } from './toDoList/to-do-list-add/to-do-list-add.component';
import { ToDoListUpdateComponent } from './toDoList/to-do-list-update/to-do-list-update.component';
import { AllToDoComponent } from './admin-components/all-to-do/all-to-do.component';
import { AdminToDoListComponent } from './toDoList/admin-to-do-list/admin-to-do-list.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
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
    CategoryUpdateComponent,
    AdminAboutMeComponent,
    AboutMeAddComponent,
    AboutMeListComponent,
    AboutMeUpdateComponent,
    StatisticsComponent,
    AllCommentsComponent,
    AccountComponent,
    AccountAddComponent,
    ToDoListListComponent,
    ToDoListAddComponent,
    ToDoListUpdateComponent,
    AllToDoComponent,
    AdminToDoListComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MaterialModule,
    ComponentsModule,
    MatPaginatorModule,
    CKEditorModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  exports: [
    StatisticsComponent,
    AllCommentsComponent,
    AllToDoComponent
  ]
})
export class AdminModule { }
