import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'priority-bar',
  templateUrl: './priority-bar.component.html',
  styleUrls: ['./priority-bar.component.css'],
})

export class PriorityBarComponent implements OnInit {

  @Input()
  public priorityRating: number;

  public ratingColor;
  public ratingColorEmpty;
  private colors = ["lightgray","green", "green", "green", "orange", "red"];

  constructor() {
  }
  ngOnInit() {
    this.ratingColor = this.colors[this.priorityRating];
    this.ratingColorEmpty = this.colors[0];
  }
}
