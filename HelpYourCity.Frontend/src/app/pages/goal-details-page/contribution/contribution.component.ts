import {Component, Input} from '@angular/core';
import {ContributionType, ContributionTypes} from '../../../types';
import {IGoal} from '../../../models/goal.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-contribution',
  templateUrl: './contribution.component.html',
  styleUrls: ['./contribution.component.scss']
})
export class ContributionComponent {
  contributionTypes = ContributionTypes;
  @Input() contributionType: ContributionType;
  @Input() goal: IGoal;
  value = 0;

  constructor(
    private _router: Router
  ) {
  }

  setValue(selectedValue: number): void {
    this.value = selectedValue;
  }

  handleNext(goal: IGoal): void {
    if (this.contributionType === ContributionTypes.VOLUNTEERING) {
      this._router.navigate(['/goal/events', goal.slug]).then();
    }
  }
}
