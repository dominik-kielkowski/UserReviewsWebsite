import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { ReviewApiService } from 'src/app/services/review-api.service';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  reviewList$!: Observable<any[]>
  id!: number;

  inspectionTypeMap: Map<number, string> = new Map()

  constructor(private service: ReviewApiService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.reviewList$ = this.service.GetReviews(this.id);
    })
  }
}
