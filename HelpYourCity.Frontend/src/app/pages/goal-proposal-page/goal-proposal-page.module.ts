import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalProposalPageComponent } from './goal-proposal-page.component';
import {Routes} from '@angular/router';
import {MatCardModule} from '@angular/material/card';
import { PersonalInformationFormComponent } from './personal-information-form/personal-information-form.component';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

const routes: Routes = [
  {
    path: '',
    component: GoalProposalPageComponent
  }
]

@NgModule({
  declarations: [
    GoalProposalPageComponent,
    PersonalInformationFormComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class GoalProposalPageModule { }
