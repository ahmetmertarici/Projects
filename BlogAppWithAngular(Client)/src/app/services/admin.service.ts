import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { Statistics } from '../models/statistics';

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

  deleteArticle(articleId:number){
    return this.httpClient.delete(`${this.apiUrl}/DeleteArticle/${articleId}`)
  }

  //*************************************************************************************************************************** */

  getAllCategories(){
    return this.httpClient.get<Category[]>(`${this.apiUrl}/GetAllCategories`)
  }

  createCategory(formData: FormData):Observable<any>{
    return this.httpClient.post(`${this.apiUrl}/CreateCategory`, formData);
  }

  getCategory(categoryId: number): Observable<Category> {
    return this.httpClient.get<Category>(`${this.apiUrl}/GetCategory/${categoryId}`);
  }

  updateCategory(categoryId: number, formData: FormData): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/UpdateCategory/${categoryId}`, formData);
  }

  deleteCategory(categoryId:number){
    return this.httpClient.delete(`${this.apiUrl}/DeleteCategory/${categoryId}`)
  }

  getStatistics(): Observable<Statistics> {
    return this.httpClient.get<Statistics>(`${this.apiUrl}/Statistics`);
  }

}
