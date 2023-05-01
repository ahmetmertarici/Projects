import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  article!: Article;

  constructor(private articleService: ArticleService, private route: ActivatedRoute) { }
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.articleService.loading = true;
      let id = Number(this.route.snapshot.paramMap.get("id"));
      this.articleService.getArticle(id).subscribe(data => {
        this.article = data;
      })
    })
  }

  rateArticle(star: number): void {
    if (this.article) {
      this.articleService.updateRating(this.article.articleId, star).subscribe(() => {
        if (this.article) {
          this.articleService.getArticleScore(this.article.articleId).subscribe((scoreData) => {
            if (this.article) {
              this.article.score = Number(scoreData);
              console.log(scoreData);
            }
          });
        }
      });
    }
  }
}
