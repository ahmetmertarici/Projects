import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comment } from '../models/comment';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private apiUrl: string="https://localhost:7000/api/Comment";

  loading: boolean = false;


  constructor(private httpClient: HttpClient) { }

  commentList(id:number){
    return this.httpClient.get<Comment[]>(`${this.apiUrl}/${id}`)
  }

  addComment(comment:Comment){
    this.loading=true;
    return this.httpClient.post(this.apiUrl, comment).pipe(
      tap(x=>{
        this.loading=false;
      })
    )
  }


}
