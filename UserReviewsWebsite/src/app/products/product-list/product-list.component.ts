import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsList$!: Observable<any[]>

  inspectionTypeMap: Map<number, string> = new Map()

  constructor(private service: ProductApiService) { }

  ngOnInit(): void {
    this.productsList$ = this.service.GetProducts();
  }
}
