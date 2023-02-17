import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Review } from '../models/review.model';

@Injectable({
  providedIn: 'root'
})
export class ReviewApiService {

 // readonly productAPIUrl = "https://userreviewswebsiteapi.azurewebsites.net/api";
  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  GetReviews(id: number): Observable<any[]> {
    return this.http.get<any>(`${this.productAPIUrl}/Review/${id}`)
  }

  AddReview(data: Review): Observable<any> {
    return this.http.post(this.productAPIUrl + '/Review', data);
  }

  DeleteReview(id: number): Observable<any> {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') })
    return this.http.delete(`${this.productAPIUrl}/Review/${id}`, { headers: tokenHeader })
  }

  EditReview(id: number, data: Review): Observable<any> {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') })
    return this.http.put(this.productAPIUrl + `/Review/${id}`, data, { headers: tokenHeader });
  }
}
