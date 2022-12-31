import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewApiService {

  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  GetReviews(id: number): Observable<any[]> {
    return this.http.get<any>(`${this.productAPIUrl}/Review/${id}`)
  }
}
