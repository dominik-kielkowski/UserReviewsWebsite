import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProductQuery } from 'src/app/models/product-query.model';
import { ProductApiService } from 'src/app/services/product-api.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsList: any;

  public query: ProductQuery = {
    SearchPhrase: '',
    PageNumber: 1,
    PageSize: 1,
    SortBy: 'Name',
    SortDirection: 'Descending'
  }

  totalPages!: number;
  itemsFrom!: number;
  itemsTo!: number;
  totalItemsCount!: number;


  constructor(private service: ProductApiService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getProducts()
  }

  getProducts() {
    const query: ProductQuery = {
      SearchPhrase: this.query.SearchPhrase,
      PageNumber: this.query.PageNumber,
      PageSize: this.query.PageSize,
      SortBy: this.query.SortBy,
      SortDirection: this.query.SortDirection
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
    if (this.query.SortBy == "Name") {
      this.query.SortBy = "Score"
    }
    else {
      this.query.SortBy = "Name"
    }

    this.getProducts()
  }

  onSwitchSortDirection() {
    if (this.query.SortDirection == "Descending") {
      this.query.SortDirection = "Ascending"
    }
    else {
      this.query.SortDirection = "Descending"
    }

    console.log(this.query.SortDirection)
    this.getProducts()
  }

  onNextPage() {
    this.query.PageNumber += 1
    this.getProducts()
  }

  onPreviousPage() {
    this.query.PageNumber -= 1
    this.getProducts()
  }

  onChangePageSize() {
    if (this.query.PageSize == 1) {
      this.query.PageSize = 3
      this.query.PageNumber = 1;
      this.getProducts()
    }
    else if (this.query.PageSize == 3) {
      this.query.PageSize = 5
      this.query.PageNumber = 1;
      this.getProducts()
    }
    else {
      this.query.PageSize = 1
      this.query.PageNumber = 1;
      this.getProducts()
    }
  }
}

