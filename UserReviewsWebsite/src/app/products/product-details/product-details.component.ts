import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductApiService } from 'src/app/product-api.service';
import { ProductScoreApiService } from 'src/app/product-score-api.service';
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
  showAddReview = false;
  score: any;

  constructor(private productService: ProductApiService, private route: ActivatedRoute, private scoreService: ProductScoreApiService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.productService.GetProduct(this.id).subscribe((product) => { this.product = product });
    })

    this.scoreService.GetProduct(this.id).subscribe((score) => { this.score = score });
  };

  onShowAddReview() {
    this.showAddReview = !this.showAddReview
  }

};