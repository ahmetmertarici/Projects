import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient:HttpClient) { }

  private apiUrl:string="https://localhost:7000/api/Admin";

  getAllArticles(){
    return this.httpClient.get<Article[]>(this.apiUrl);
  }

  createArticle(formData: FormData): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/CreateArticle`, formData);
  }

  updateIsApproved(articleId: number): Observable<any> {
    return this.httpClient.post<any>(`${this.apiUrl}/UpdateIsApproved/${articleId}`, {});
  }

}
