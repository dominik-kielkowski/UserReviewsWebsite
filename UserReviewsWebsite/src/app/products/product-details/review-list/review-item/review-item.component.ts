import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ReviewApiService } from 'src/app/services/review-api.service';

@Component({
  selector: 'app-review-item',
  templateUrl: './review-item.component.html',
  styleUrls: ['./review-item.component.css']
})
export class ReviewItemComponent implements OnInit {
  @Input() item: any;
  inEditMode = false;
  reviewTitle: string = "";
  reviewBody: string = "";
  reviewScore: number = 0;

  constructor(private reviewService: ReviewApiService) {
  }

  ngOnInit(): void {

    
  }

  onDeleteReview() {
    this.reviewService.DeleteReview(this.item.id).subscribe()

    window.location.reload();
  }

  onEditReview() {
    this.reviewTitle = this.item.title;
    this.reviewBody = this.item.reviewBody;
    this.reviewScore = this.item.score;

    this.inEditMode = !this.inEditMode
  }

  onSubmitEditReview() {
    var review = {
      Title: this.reviewTitle,
      ReviewBody: this.reviewBody,
      Score: this.reviewScore,
      ProductId: this.item.id,
      UserId: this.item.userId
    }

    this.reviewService.EditReview(review.ProductId, review).subscribe()

    this.inEditMode = !this.inEditMode

    window.location.reload();
  }
}
