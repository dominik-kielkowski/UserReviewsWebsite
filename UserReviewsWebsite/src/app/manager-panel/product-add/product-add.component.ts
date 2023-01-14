import { Component, OnInit } from '@angular/core';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  imagePath = "";
  productName = "";
  productDescription="";

  constructor(private productService: ProductApiService) { }

  ngOnInit(): void {
  }

  onSaveChanges() {
    var product = {
      Name: this.productName,
      ImagePath: this.imagePath,
      Description: this.productDescription,
      AverageScore: 10
    }

    this.productService.AddProduct(product).subscribe()
  }
}
