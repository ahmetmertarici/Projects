import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }
  private apiUrl = "https://localhost:7000/api/Account";

  login(email: string, password: string, rememberMe: boolean): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { email, password, rememberMe }).pipe(
      map(response => {
        // Store user role and token here
        localStorage.setItem('userRole', response.userRole);
        localStorage.setItem('token', response.token);
      })
    );
  }

  isAuthenticated(): boolean {
    // Check if user is logged in and has 'Admin' role
    const userRole = localStorage.getItem('userRole');
    const token = localStorage.getItem('token');

    return userRole === 'Admin' && token != null;
  }


  logout(): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/logout`, {}).pipe(
      map(() => {
        localStorage.removeItem('userRole');
        localStorage.removeItem('token');
      })
    );
  }

}
