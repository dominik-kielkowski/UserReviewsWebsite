import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductApiService } from 'src/app/product-api.service';
import { ReviewApiService } from 'src/app/review-api.service';
import { UserApiService } from 'src/app/user-api.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  id!: number;
  product: any;

  constructor(private service: ProductApiService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.service.GetProduct(this.id).subscribe((product) => { this.product = product });
    })
  };

};