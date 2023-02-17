import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  //readonly productAPIUrl = "https://userreviewswebsiteapi.azurewebsites.net/api";
  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  LoginUser(data: User): Observable<any> {
    return this.http.post<any>(`${this.productAPIUrl}/User/login`, data)
  }

  GetUserProfile() {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') })
    return this.http.get(`${this.productAPIUrl}/User`, { headers: tokenHeader });
  }

  RegisterUser(data: User) {
    return this.http.post(`${this.productAPIUrl}/User`, data)
  }
}
