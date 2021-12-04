import {Component, ViewChild} from '@angular/core';
import {SelectedFormTypes, SelectedFromType} from '../../types';
import {PersonalInformationFormComponent} from './personal-information-form/personal-information-form.component';
import {GoalFormComponent} from './goal-form/goal-form.component';
import {ProposalService} from '../../services/proposal.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Router} from '@angular/router';

@Component({
  selector: 'app-goal-proposal-page',
  templateUrl: './goal-proposal-page.component.html',
  styleUrls: ['./goal-proposal-page.component.scss']
})
export class GoalProposalPageComponent {
  selectedFormTypes = SelectedFormTypes;
  formType = SelectedFormTypes.PERSONAL_INFO;

  @ViewChild('personalInfoForm')
  personalInfoForm: PersonalInformationFormComponent;

  @ViewChild('goalForm')
  goalForm: GoalFormComponent;

  constructor(
    private readonly _proposalService: ProposalService,
    private readonly _snack: MatSnackBar,
    private readonly _router: Router
  ) {
  }

  switchForm(formType: SelectedFromType): void {
    this.formType = formType;
  }

  async submit(): Promise<void> {
    const payload = {...this.personalInfoForm.form.value, ...{goal: this.goalForm.form.value}};
    try {
      this.goalForm.form.reset();
      this.personalInfoForm.form.reset();
      await this._proposalService.addProposal(payload).toPromise();
      this._snack.open('Goal proposal was successful!', 'Close');
      this._router.navigate(['goals']).then();
    } catch (err: any) {
      this._snack.open(err.error, 'Close');
    }
  }
}
