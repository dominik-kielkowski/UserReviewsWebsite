import { Component, OnInit } from '@angular/core';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-management-list',
  templateUrl: './management-list.component.html',
  styleUrls: ['./management-list.component.css']
})
export class ManagementListComponent implements OnInit {
  products: any;
  constructor(private productService: ProductApiService) { }

  ngOnInit(): void {
    
    this.products = this.productService.GetProducts()
  }

}
