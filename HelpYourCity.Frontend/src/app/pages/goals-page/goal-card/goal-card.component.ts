import {Component, Input} from '@angular/core';
import {IGoal} from '../../../models/goal.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-goal-card',
  templateUrl: './goal-card.component.html',
  styleUrls: ['./goal-card.component.scss']
})
export class GoalCardComponent {
  @Input() goal: IGoal;

  constructor(
    private _router: Router
  ) {
  }

  goToEvents() {
    this._router.navigate(['goal/donors', this.goal.slug]).then();
  }
}
