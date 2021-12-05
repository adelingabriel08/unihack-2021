import {Component, OnInit} from '@angular/core';
import {IGoal} from '../../models/goal.model';
import {IDonor} from '../../models/donor.model';
import {ActivatedRoute} from '@angular/router';
import {GoalsService} from '../../services/goals.service';

@Component({
  selector: 'app-goal-donors-page',
  templateUrl: './goal-donors-page.component.html',
  styleUrls: ['./goal-donors-page.component.scss']
})
export class GoalDonorsPageComponent implements OnInit {
  goal: IGoal;
  donors: IDonor[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'message', 'quantity'];

  constructor(
    private readonly _route: ActivatedRoute,
    private readonly _goalsService: GoalsService
  ) {
  }

  ngOnInit(): void {
    const slug = this._route.snapshot.paramMap.get('slug');
    this._goalsService.getBySlug(slug!).subscribe(res => {
      this.goal = res;
      this._goalsService.getDonors(this.goal.id).subscribe(donors => {
        this.donors = donors;
      });
    });
  }
}
