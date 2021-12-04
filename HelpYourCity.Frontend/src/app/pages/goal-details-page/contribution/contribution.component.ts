import {Component, Input} from '@angular/core';
import {ContributionType, ContributionTypes} from '../../../types';
import {IGoal} from '../../../models/goal.model';

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

  setValue(selectedValue: number): void {
    this.value = selectedValue;
  }
}
