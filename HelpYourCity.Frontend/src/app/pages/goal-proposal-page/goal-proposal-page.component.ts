import { Component, ViewChild } from '@angular/core';
import {SelectedFormTypes, SelectedFromType} from '../../types';
import {PersonalInformationFormComponent} from './personal-information-form/personal-information-form.component';
import {GoalFormComponent} from './goal-form/goal-form.component';

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

  constructor() { }

  switchForm(formType: SelectedFromType): void {
    this.formType = formType;
  }
}
