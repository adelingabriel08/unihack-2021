import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {GoalsPageComponent} from './goals-page.component';
import {RouterModule, Routes} from '@angular/router';
import {GoalCardComponent} from './goal-card/goal-card.component';
import {MatCardModule} from '@angular/material/card';
import {SharedModule} from '../../shared/shared.module';

const routes: Routes = [
  {
    path: '',
    component: GoalsPageComponent
  }
];

@NgModule({
  declarations: [
    GoalsPageComponent,
    GoalCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatCardModule,
    SharedModule
  ]
})
export class GoalsPageModule {
}
