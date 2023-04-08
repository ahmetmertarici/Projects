import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Observable, tap } from 'rxjs';
import { ArticlePg } from '../models/article-pg';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private httpClient: HttpClient) { }

  public loading:boolean=true;
  private apiUrl: string="https://localhost:7000/api/Articles";

  public getArticles(page:number,pageSize:number){
    let api = `${this.apiUrl}/${page}/${pageSize}`;
    return this.httpClient.get<ArticlePg>(api).pipe(tap(x=>{
      this.loading=false;
    }))
  }

  getArticle(id:number){
    let api = `${this.apiUrl}/${id}`;
    return this.httpClient.get<Article>(api).pipe(tap(x=>{
      this.loading=false;
    }))
  }

  getArticleWithCategory(categoryId:number,page:number,pageSize:number ){
    let api = `${this.apiUrl}/GetArticleWithCategory/${categoryId}/${page}/${pageSize}`;
    return this.httpClient.get<ArticlePg>(api).pipe(tap(x=>{
      this.loading=false;
    }))
  }

  getSearchArticles(searchText: string, page: number, pageSize: number) {
    let api = `${this.apiUrl}/Search/${searchText}/${page}/${pageSize}`;

    return this.httpClient.get<ArticlePg>(api).pipe(
      tap(x => {
        this.loading = false;
      })
    );
  }

  getArticlesByMostView(){
    let api = `${this.apiUrl}/GetArticlesByMostView`;

    return this.httpClient.get<Article[]>(api);
  }

  getHighScoresArticles(){
    let api = `${this.apiUrl}/GetHighScoresArticles`;

    return this.httpClient.get<Article[]>(api);

  }

  getAllArticles(){
    return this.httpClient.get<Article[]>(this.apiUrl);
  }





}
