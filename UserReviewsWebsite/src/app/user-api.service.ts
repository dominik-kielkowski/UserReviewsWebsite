import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  LoginUser(data: any): Observable<any> {
    return this.http.post<any>(`${this.productAPIUrl}/User/login`, data)
  }

  GetUserProfile() {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') })
    return this.http.get(`${this.productAPIUrl}/User`, { headers: tokenHeader });
  }

}
