import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Review } from 'src/app/models/review.model';
import { ReviewApiService } from 'src/app/services/review-api.service';
import { UserApiService } from 'src/app/services/user-api.service';

@Component({
  selector: 'app-review-post',
  templateUrl: './review-post.component.html',
  styleUrls: ['./review-post.component.css']
})
export class ReviewPostComponent implements OnInit {

  constructor(private userService: UserApiService, private reviewService: ReviewApiService) { }

  @Input() id: any;
  userDetails: any;
  title = "";
  reviewBody = "";
  score = 0;

  ngOnInit(): void {
    this.userService.GetUserProfile().subscribe(
      res => {
        this.userDetails = res
      }
    )
  }

  addReview() {
    var review: Review= {
      Title: this.title,
      ReviewBody: this.reviewBody,
      Score: this.score,
      ProductId: this.id,
      UserId: this.userDetails.id
    }

    this.reviewService.AddReview(review).subscribe()
    window.location.reload();
  }
}
