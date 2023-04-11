import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  @Input() totalCount: number = 0;
  @Input() articles: Article[] = [];
  @Input() page: number = 0;
  @Input() pageSize: number = 0;
  @Input() typeList: string | undefined;

  constructor(private articleService: ArticleService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.articleService.loading = true;

  }

  pageChanged(event: any) {
    this.articleService.loading = true;
    this.page = event;
    switch (this.typeList) {
      case "home":
        this.router.navigateByUrl(`/sayfa/${this.page}`)

        break;
      case "category":

        let categoryName = this.route.snapshot.paramMap.get("name");
        let categoryId = this.route.snapshot.paramMap.get("id");

        this.router.navigateByUrl(`/kategori/${categoryName}/${categoryId}/sayfa/${this.page}`)

        break;
      case "search":
        let searchText = this.route.snapshot.queryParamMap.get("s");
        this.router.navigateByUrl(`/arama/sayfa/${this.page}?s=${searchText}`);

        break;
      default:
        break;
    }

  }

}
