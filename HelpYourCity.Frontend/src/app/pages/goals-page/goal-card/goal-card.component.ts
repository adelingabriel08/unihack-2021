import {Component, Input} from '@angular/core';
import {IGoal} from '../../../models/goal.model';

@Component({
  selector: 'app-goal-card',
  templateUrl: './goal-card.component.html',
  styleUrls: ['./goal-card.component.scss']
})
export class GoalCardComponent {
  @Input() goal: IGoal;

  constructor() {
  }
}
