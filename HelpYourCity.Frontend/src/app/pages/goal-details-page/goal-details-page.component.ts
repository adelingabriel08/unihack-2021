import {Component, OnInit} from '@angular/core';
import {GoalsService} from '../../services/goals.service';
import {ActivatedRoute} from '@angular/router';
import {IGoal} from '../../models/goal.model';
import {ContributionTypes} from '../../types';

@Component({
  selector: 'app-goal-details-page',
  templateUrl: './goal-details-page.component.html',
  styleUrls: ['./goal-details-page.component.scss']
})
export class GoalDetailsPageComponent implements OnInit {
  goal: IGoal;
  contributionTypes = ContributionTypes;

  constructor(
    private readonly _route: ActivatedRoute,
    private readonly _goalsService: GoalsService
  ) {
  }

  ngOnInit(): void {
    const slug = this._route.snapshot.paramMap.get('slug');
    this._goalsService.getBySlug(slug!).subscribe(res => {
      this.goal = res;
    });
  }
}
