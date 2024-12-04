import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';

const api = 'http://localhost:5094/api';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http:HttpClient,
    private router: Router
  ) { }

  login(account: { email: string; password: string }): Observable<any> {
    return this.http.post(`${api}/TaiKhoan/login`, account).pipe(
      map((response: any) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('role', response.user.role);
        return response.user.role;
      })
    );
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getUserRole(): string | null {
    return localStorage.getItem('role');
  }
}
