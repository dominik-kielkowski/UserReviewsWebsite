import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductApiService } from 'src/app/services/product-api.service';

@Component({
  selector: 'app-management-details',
  templateUrl: './management-details.component.html',
  styleUrls: ['./management-details.component.css']
})
export class ManagementDetailsComponent implements OnInit {

  public product: Product = {
    Name: '',
    Description: '',
    ImagePath: ''
  }

  id!: number;
  inEditMode = false;

  error!: Error;


  constructor(private route: ActivatedRoute, private productService: ProductApiService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.productService.GetProduct(this.id).subscribe(
        res => {
          this.product.Name = res.name
          this.product.Description = res.description
          this.product.ImagePath = res.imagePath
      },
        error => {
        console.log(error)
        this.error = error.error.title
      });
    });
  };

  onSwitchToEdit() {
    this.inEditMode = !this.inEditMode
  }

  onSaveChanges() {

    this.productService.UpdateProduct(this.id, this.product).subscribe(
      res => {
        this.inEditMode = !this.inEditMode

        window.location.reload();
      },
      error => {
        console.log(error.error)
        this.error = error.error.title
      }
    )
  }

  onDeleteProduct() {
    this.productService.DeleteProduct(this.id).subscribe(
      res => {
        this.router.navigate(['manage'])
      },
      error => {
        console.log(error)
        this.error = error.message
      })

  }
}
