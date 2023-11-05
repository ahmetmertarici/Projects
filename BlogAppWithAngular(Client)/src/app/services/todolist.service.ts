import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToDoList } from '../models/to-do-list';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodolistService {

  constructor(private httpClient:HttpClient) { }
  private apiUrl:string="https://localhost:7000/api/ToDoList"

  getAllToDo(){
    return this.httpClient.get<ToDoList[]>(`${this.apiUrl}/GetAllToDo`);
  }
  updateCompleted(toDo: ToDoList) {
    return this.httpClient.post(`${this.apiUrl}/UpdateCompleted/${toDo.id}`, toDo);
  }
  createToDo(formData: FormData): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/CreateToDo`, formData);
  }
  getTodo(id:number): Observable<ToDoList>{
    return this.httpClient.get<ToDoList>(`${this.apiUrl}/GetTodo/${id}`);
  }
  updateTodo(id: number, formData: FormData): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/UpdateTodo/${id}`, formData);
  }
  deleteTodo(id:number){
    return this.httpClient.delete(`${this.apiUrl}/DeleteTodo/${id}`)
  }
}
