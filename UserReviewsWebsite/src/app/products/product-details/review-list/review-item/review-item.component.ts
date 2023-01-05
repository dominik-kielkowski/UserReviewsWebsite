import { Component, Input, OnInit } from '@angular/core';
import { ReviewApiService } from 'src/app/review-api.service';

@Component({
  selector: 'app-review-item',
  templateUrl: './review-item.component.html',
  styleUrls: ['./review-item.component.css']
})
export class ReviewItemComponent implements OnInit {
  @Input() item: any;

  constructor(private reviewService: ReviewApiService) {
  }

  ngOnInit(): void {
  }

  onDeleteReview() {
    console.log(this.item.id)
    this.reviewService.DeleteReview(this.item.id).subscribe()
  }

}
