import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductQuery } from 'src/app/models/product-query.model';
import { ProductApiService } from 'src/app/services/product-api.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsList: any;

  PageNumber = 1;
  pageSize = 1;
  SearchPhrase = "";
  SortBy = "Name"
  SortDirection = "Descending"

  totalPages: any;
  itemsFrom: any;
  itemsTo: any;
  totalItemsCount: any;


  constructor(private service: ProductApiService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getProducts()
  }

  getProducts() {
    const query: ProductQuery = {
      SearchPhrase: this.SearchPhrase,
      PageNumber: this.PageNumber,
      PageSize: this.pageSize,
      SortBy: this.SortBy,
      SortDirection: this.SortDirection
    }

    this.service.GetProducts(query).subscribe({
      next: (response: any) => {
        this.productsList = response.items;
        this.totalPages = response.totalPages
        this.itemsFrom = response.itemsFrom
        this.itemsTo = response.itemsTo
        this.totalItemsCount = response.totalItemsCount
      },
      error: err => console.log(err)
    });
  }

  onSwitchSortBy() {
    if (this.SortBy == "Name") {
      this.SortBy = "Score"
    }
    else {
      this.SortBy = "Name"
    }

    this.getProducts()
  }

  onSwitchSortDirection() {
    if (this.SortDirection == "Descending") {
      this.SortDirection = "Ascending"
    }
    else {
      this.SortDirection = "Descending"
    }

    console.log(this.SortDirection)
    this.getProducts()
  }

  onNextPage() {
    this.PageNumber += 1
    this.getProducts()
  }

  onPreviousPage() {
    this.PageNumber -= 1
    this.getProducts()
  }

  onChangePageSize() {
    if (this.pageSize == 1) {
      this.pageSize = 3
      this.PageNumber = 1;
      this.getProducts()
    }
    else if (this.pageSize == 3) {
      this.pageSize = 5
      this.PageNumber = 1;
      this.getProducts()
    }
    else {
      this.pageSize = 1
      this.PageNumber = 1;
      this.getProducts()
    }
  }
}

