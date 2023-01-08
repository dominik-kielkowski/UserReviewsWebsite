import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-management-item',
  templateUrl: './management-item.component.html',
  styleUrls: ['./management-item.component.css']
})
export class ManagementItemComponent implements OnInit {
  @Input() index: any;
  @Input() product: any;
  constructor() { }

  ngOnInit(): void {
  }

}
