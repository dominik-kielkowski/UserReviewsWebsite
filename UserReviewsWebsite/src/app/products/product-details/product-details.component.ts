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
  userDetails: any;

  constructor(private service: ProductApiService, private route: ActivatedRoute, private userService: UserApiService,
    private reviewService: ReviewApiService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.service.GetProduct(this.id).subscribe((product) => { this.product = product });
    })


    this.userService.GetUserProfile().subscribe(
      res => {
        console.log(res)
        this.userDetails = res
      },
      err => {
        console.log(err);
      }
    )

  };

  addReview(form: NgForm) {
    var review = {
      Title: form.value.title,
      ReviewBody: form.value.reviewBody,
      Score: form.value.score,
      ProductId: this.id,
      UserId: this.userDetails.id
    }


    this.reviewService.AddReview(review).subscribe()
    console.log(review);


  }
};