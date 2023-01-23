import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsList: any;
  pageSize = 2;
  SearchPhrase = "";

  totalPages: any;
  itemsFrom: any;
  itemsTo: any;
  totalItemsCount: any;


  constructor(private service: ProductApiService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getProducts()
  }

  getProducts() {
    this.service.GetProducts(this.SearchPhrase, this.pageSize).subscribe({
      next: (response: any) => {
        this.productsList = response.items;
        this.totalPages = response.totalPages
        this.itemsFrom = response.itemsFrom
        this.itemsTo = response.itemsTo
        this.totalItemsCount = response.totalItemsCount
        console.log(response)

      },
      error: err => console.log(err)
    });
  }
}

