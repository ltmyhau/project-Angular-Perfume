import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';

const api = 'http://localhost:5094/api';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  login(username: string,password: string, role: string = 'admin'):Observable<any>{
    return this.http.post<any>(`${api}/TaiKhoan/login`,{username,password,role},httpOptions);
  }
}
