import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-category-articles',
  templateUrl: './category-articles.component.html',
  styleUrls: ['./category-articles.component.css']
})
export class CategoryArticlesComponent implements OnInit {
  page: number = 1;
  articles: Article[] = [];
  totalCount: number = 0;
  pageSize: number = 7;
  loadingItem:number=5;
  ajax: any;
  categoryId:number=0;
  constructor(private articleService: ArticleService, private router: Router, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>{
      if(this.ajax!=null) this.ajax.unsubscribe();
      this.articleService.loading=true;
      this.articles=[];
      this.totalCount=0;
      if (params.get("id")) {
        this.categoryId=Number(params.get("id"));
      }
      if (params.get("page")) {
        this.page = Number(params.get("page"))
      }

      this.ajax= this.articleService.getArticleWithCategory(this.categoryId, this.page, this.pageSize).subscribe(data=>{
        this.articles=data.articles,
        this.totalCount=data.totalCount
      })

    })
  }

}
