import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'priority-bar',
  templateUrl: './priority-bar.component.html',
  styleUrls: ['./priority-bar.component.css'],
})

export class PriorityBarComponent implements OnInit {

  @Input()
  public priorityRating: number;

  public ratingColor: string;
  public ratingColorEmpty: string;
  public ratingText: string;
  private colors = ["lightgray","green", "green", "green", "orange", "red"];
  private priorityText = ["Lowest", "Lowest", "Low", "Normal", "Important", "Urgent"];

  constructor() {
  }
  ngOnInit() {
    this.ratingText = this.priorityText[this.priorityRating];
    this.ratingColor = this.colors[this.priorityRating];
    this.ratingColorEmpty = this.colors[0];
  }
}
