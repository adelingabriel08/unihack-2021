import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {GoalDetailsPageComponent} from './pages/goal-details-page/goal-details-page.component';
import {GoalEventsPageComponent} from './pages/goal-events-page/goal-events-page.component';

const routes: Routes = [
  {
    path: 'goals',
    loadChildren: () => import('./pages/goals-page/goals-page.module').then(m => m.GoalsPageModule)
  },
  {
    path: 'propose-goal',
    loadChildren: () => import('./pages/goal-proposal-page/goal-proposal-page.module').then(m => m.GoalProposalPageModule)
  },
  {
    path: 'goal/:slug',
    component: GoalDetailsPageComponent
  },
  {
    path: 'goal/events/:slug',
    component: GoalEventsPageComponent
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
export class AppRoutingModule {
}
