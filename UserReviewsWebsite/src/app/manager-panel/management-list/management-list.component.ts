import { Component, OnInit } from '@angular/core';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-management-list',
  templateUrl: './management-list.component.html',
  styleUrls: ['./management-list.component.css']
})
export class ManagementListComponent implements OnInit {
  productsList: any;
  pageSize = 2;
  SearchPhrase = "";
  constructor(private productService: ProductApiService) { }

  ngOnInit(): void {

    this.getProducts()
    console.log(this.productsList)
  }

  getProducts() {
    this.productService.GetProducts(this.SearchPhrase, this.pageSize).subscribe({
      next: (response: any) => {
        this.productsList = response.items;
      },
      error: err => console.log(err)
    });
  }

}
