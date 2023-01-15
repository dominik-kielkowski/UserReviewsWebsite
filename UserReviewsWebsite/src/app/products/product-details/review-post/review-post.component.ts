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

  ngOnInit(): void {
    this.userService.GetUserProfile().subscribe(
      res => {
        this.userDetails = res
      },
      err => {
      }
    )
  }

  addReview(form: NgForm) {
    var review = {
      Title: form.value.title,
      ReviewBody: form.value.reviewBody,
      Score: form.value.score,
      ProductId: this.id,
      UserId: this.userDetails.id
    }

    this.reviewService.AddReview(review).subscribe()
  }
}
