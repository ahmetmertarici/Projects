import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuCategoryComponent } from './menu-category/menu-category.component';
import { RouterModule } from '@angular/router';
import { PageTitleComponent } from './page-title/page-title.component';
import { ArticlesComponent } from './articles/articles.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { UrlformatPipe } from '../Pipes/urlformat.pipe';
import { MenuArticleMostViewComponent } from './menu-article-most-view/menu-article-most-view.component';
import { MenuArticleHighScoreComponent } from './menu-article-high-score/menu-article-high-score.component';



@NgModule({
  declarations: [
    MenuCategoryComponent,
    PageTitleComponent,
    ArticlesComponent,
    UrlformatPipe,
    MenuArticleMostViewComponent,
    MenuArticleHighScoreComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgxPaginationModule
  ],
  exports:[
    MenuCategoryComponent,
    PageTitleComponent,
    ArticlesComponent,
    UrlformatPipe,
    MenuArticleMostViewComponent,
    MenuArticleHighScoreComponent

  ]
})
export class ComponentsModule { }
