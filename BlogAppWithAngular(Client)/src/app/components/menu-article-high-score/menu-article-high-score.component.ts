import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-menu-article-high-score',
  templateUrl: './menu-article-high-score.component.html',
  styleUrls: ['./menu-article-high-score.component.css']
})
export class MenuArticleHighScoreComponent implements OnInit {
  articles:Article[]=[];
  constructor(private articleService:ArticleService){}
  ngOnInit(): void {
    this.articleService.getHighScoresArticles().subscribe(data=>{
      this.articles=data;
    })
  }

}
