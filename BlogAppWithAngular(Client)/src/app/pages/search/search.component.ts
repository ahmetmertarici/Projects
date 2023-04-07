import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  page: number = 1;
  totalCount: number=0;
  pageSize: number = 7;
  articles: Article[] = [];
  ajax: any;
  searchText:any;

  constructor(private articleService: ArticleService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.url.subscribe(params => {
      if (this.ajax != null) this.ajax.unsubscribe();

      this.articles = [];
      this.totalCount = 0;
      this.articleService.loading = true;

      if (this.route.snapshot.paramMap.get("page")) {
        this.page = Number(this.route.snapshot.paramMap.get("page"));
      }

      this.searchText = this.route.snapshot.queryParamMap.get("s");

      this.ajax = this.articleService
        .getSearchArticles(this.searchText, this.page, this.pageSize)
        .subscribe(data => {
          this.articles = data.articles;
          this.totalCount = data.totalCount;
        });
    });
  }

}
