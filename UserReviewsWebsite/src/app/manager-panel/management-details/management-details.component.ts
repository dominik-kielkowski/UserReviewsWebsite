import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ProductApiService } from 'src/app/product-api.service';

@Component({
  selector: 'app-management-details',
  templateUrl: './management-details.component.html',
  styleUrls: ['./management-details.component.css']
})
export class ManagementDetailsComponent implements OnInit {

  product: any;
  id!: number;
  inEditMode = false;
  productName: string = "";
  imagePath: string = "";
  productDescription: string = "";
    

  constructor(private route: ActivatedRoute,private productService: ProductApiService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.productService.GetProduct(this.id).subscribe((product) => { this.product = product });
    });
  };

  onSwitchToEdit() {
    this.imagePath = this.product.imagePath
    this.productName = this.product.name
    this.productDescription = this.product.description
    this.inEditMode = !this.inEditMode
  }

  onSaveChanges() {
    var product = {
      Name: this.productName,
      ImagePath: this.imagePath,
      Description: this.productDescription,
      AverageScore: 10
    }

    this.productService.UpdateProduct(this.id, product).subscribe()

    this.inEditMode = !this.inEditMode

    window.location.reload();
  }

  onDeleteProduct() {
      this.productService.DeleteProduct(this.id).subscribe(
        (response: any) => {
          window.location.reload();
        }
      )

      this.router.navigate(['manage'])
    }
  }
