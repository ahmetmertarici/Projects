import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Aboutme } from '../models/aboutme';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AboutmeService {

  constructor(private httpClient:HttpClient) { }

  private apiUrl:string="https://localhost:7000/api/AboutMe";

  getAboutMeContent(){
    return this.httpClient.get<Aboutme[]>(this.apiUrl);
  }

  getAllAboutMe(){
    return this.httpClient.get<Aboutme[]>(`${this.apiUrl}/GetAllAboutMe`);
  }

  deleteAboutMe(aboutMeId:number){
    return this.httpClient.delete(`${this.apiUrl}/DeleteAboutMe/${aboutMeId}`)
  }

  createAboutMe(formData: FormData): Observable<any>{
    return this.httpClient.post(`${this.apiUrl}/CreateAboutMe`, formData);
  }


  updateAboutMe(aboutMeId: number, formData: FormData): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/UpdateAboutMe/${aboutMeId}`, formData);
  }

  getAboutMe(aboutMeId:number): Observable<Aboutme>{
    return this.httpClient.get<Aboutme>(`${this.apiUrl}/GetAboutMe/${aboutMeId}`);
  }

  updateAboutMeIsApproved(aboutMeId:number){
    return this.httpClient.post<any>(`${this.apiUrl}/UpdateAboutMeIsApproved/${aboutMeId}`, {});
  }



}
