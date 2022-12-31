import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  LoginUser(data: any): Observable<any> {
    return this.http.get<any>(`${this.productAPIUrl}/User/login`)
  }
}
