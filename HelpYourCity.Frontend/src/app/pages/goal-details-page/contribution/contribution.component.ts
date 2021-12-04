import {Component, Input} from '@angular/core';
import {ContributionType, ContributionTypes} from '../../../types';
import {IGoal} from '../../../models/goal.model';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import {PaymentFormComponent} from '../payment-form/payment-form.component';

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
    private readonly _router: Router,
    private readonly _dialog: MatDialog
  ) {
  }

  setValue(selectedValue: number): void {
    this.value = selectedValue;
  }

  handleNext(goal: IGoal): void {
    if (this.contributionType === ContributionTypes.VOLUNTEERING) {
      this._router.navigate(['/goal/events', goal.slug]).then();
    } else if (this.contributionType === ContributionTypes.DONATION) {
      this._dialog.open(PaymentFormComponent, {
        data: {
          quantity: this.value,
          goal: this.goal
        }
      })
    }
  }

  isDisabled(): boolean {
    if (this.contributionType === ContributionTypes.DONATION) {
      return this.value === 0;
    }
    return false;
  }
}
