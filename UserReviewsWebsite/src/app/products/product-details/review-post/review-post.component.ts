import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ReviewApiService } from 'src/app/review-api.service';
import { UserApiService } from 'src/app/user-api.service';

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
  score = "";

  ngOnInit(): void {
    this.userService.GetUserProfile().subscribe(
      res => {
        this.userDetails = res
      }
    )
  }

  addReview() {
    var review = {
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
