import { Component, Input, OnInit } from '@angular/core';
import { ProductScoreApiService } from 'src/app/product-score-api.service';

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
    this.scoreService.GetProduct(this.item.id).subscribe((score) => { this.score = score });
  }
}
