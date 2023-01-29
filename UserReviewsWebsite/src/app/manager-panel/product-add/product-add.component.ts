import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductApiService } from 'src/app/services/product-api.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  imagePath = "";
  productName = "";
  productDescription = "";
  error?: Error;

  constructor(private productService: ProductApiService, private router: Router) { }

  ngOnInit(): void {
  }

  onSaveChanges() {
    const product: Product = {
      Name: this.productName,
      ImagePath: this.imagePath,
      Description: this.productDescription
    }

    this.productService.AddProduct(product).subscribe(
      res => {
        this.router.navigate(['manage'])
      },
      error => {
        console.log(error)
        this.error = error.error.title
      })
  }
}
