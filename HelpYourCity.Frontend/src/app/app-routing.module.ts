import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GoalDetailsPageComponent} from './pages/goal-details-page/goal-details-page.component';

const routes: Routes = [
  {
    path: 'goals',
    loadChildren: () => import('./pages/goals-page/goals-page.module').then(m => m.GoalsPageModule)
  },
  {
    path: 'goal/:slug',
    component: GoalDetailsPageComponent
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'goals'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
