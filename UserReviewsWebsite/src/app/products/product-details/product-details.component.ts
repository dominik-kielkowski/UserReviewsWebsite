import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductApiService } from 'src/app/services/product-api.service';
import { ProductScoreApiService } from 'src/app/services/product-score-api.service';
import { ReviewApiService } from 'src/app/services/review-api.service';
import { UserApiService } from 'src/app/services/user-api.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  id!: number;
  product: any;
  showAddReview = false;
  score: any;

  constructor(private productService: ProductApiService, private route: ActivatedRoute, private scoreService: ProductScoreApiService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.productService.GetProduct(this.id).subscribe(res => {
        console.log(res)
        this.product = res;
      },
      error => {
        console.log(error)
      });
    })

    this.scoreService.GetProductScore(this.id).subscribe(res => {
      console.log(res)
      this.score = res;
    },
    error => {
      console.log(error)
    });
  };

  onShowAddReview() {
    this.showAddReview = !this.showAddReview
  }

};