import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor() { }

  numbers: string[] = [];
  number!: string;

  ngOnInit(): void {
  }

  onSubmit(){
    this.numbers.push(this.number)
    console.log(this.numbers)
    this.number=""
  }
}
