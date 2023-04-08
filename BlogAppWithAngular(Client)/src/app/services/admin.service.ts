import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) { }

  private apiUrl: string = "https://localhost:7000/api/Admin";

  getArticle(articleId: number): Observable<Article> {
    return this.httpClient.get<Article>(`${this.apiUrl}/GetArticle/${articleId}`);
  }


  getAllArticles() {
    return this.httpClient.get<Article[]>(this.apiUrl);
  }

  createArticle(formData: FormData): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/CreateArticle`, formData);
  }

  updateIsApproved(articleId: number): Observable<any> {
    return this.httpClient.post<any>(`${this.apiUrl}/UpdateIsApproved/${articleId}`, {});
  }

  saveArticlePicture(image: any) {
    return this.httpClient.post<any>(`${this.apiUrl}/SaveArticlePicture`, image);
  }


  updateArticle(articleId: number, formData: FormData): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/UpdateArticle/${articleId}`, formData);
  }


}
