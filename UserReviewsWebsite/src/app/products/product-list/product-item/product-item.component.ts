import { Component, Input, OnInit } from '@angular/core';
import { ProductScoreApiService } from 'src/app/services/product-score-api.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() item: any;
  score: any;

  constructor(private scoreService: ProductScoreApiService) { }

  ngOnInit(): void {
    this.scoreService.GetProductScore(this.item.id).subscribe(res => {
      console.log(res)
      this.score = res;
    },
    error => {
      console.log(error)
    });
  }
}
