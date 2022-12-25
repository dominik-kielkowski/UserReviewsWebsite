import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductApiService } from '../product-api.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  productsList$!: Observable<any[]>

  inspectionTypeMap: Map<number, string> = new Map()

  constructor(private service: ProductApiService) { }

  ngOnInit(): void {
    this.productsList$ = this.service.GetProducts();
  }

}
