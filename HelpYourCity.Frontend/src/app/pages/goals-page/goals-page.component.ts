import {Component, OnInit} from '@angular/core';
import {IGoal} from '../../models/goal.model';
import {GoalsService} from '../../services/goals.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-goals-page',
  templateUrl: './goals-page.component.html',
  styleUrls: ['./goals-page.component.scss']
})
export class GoalsPageComponent implements OnInit {
  goals: IGoal[] = [];

  constructor(
    private readonly _goalsService: GoalsService,
    private readonly _router: Router
  ) { }

  ngOnInit(): void {
    this._goalsService.getAll().subscribe(res => {
      this.goals = res;
    });
  }

  goToDetails(goal: IGoal): void {
    this._router.navigate(['/goal', goal.slug]).then();
  }
}
