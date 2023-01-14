import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductApiService {

  readonly productAPIUrl = "https://localhost:7143/api";

  constructor(private http: HttpClient) { }

  GetProducts(): Observable<any[]> {
    return this.http.get<any>(this.productAPIUrl + '/Product');
  }

  GetProduct(id: number): Observable<any> {
    return this.http.get<any>(this.productAPIUrl + `/Product/${id}`);
  }

  AddProduct(data: any): Observable<any> {
    return this.http.post(this.productAPIUrl + '/Product', data);
  }

  UpdateProduct(id: number | string, data: any) {
    return this.http.put(this.productAPIUrl + `/Product/${id}`, data);
  }

  DeleteProduct(id: number) {
    return this.http.delete(this.productAPIUrl + `/Product/${id}`);
  }

}
