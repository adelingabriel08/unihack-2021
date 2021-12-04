import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit {
  @Input() goal: number;
  @Input() current: number;
  percent: number;

  ngOnInit(): void {
    this.percent = (this.current * 100) / this.goal;
    if (this.percent > 100) {
      this.percent = 100;
    }
  }
}
