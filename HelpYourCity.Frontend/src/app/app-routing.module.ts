import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'goals',
    loadChildren: () => import('./pages/goals-page/goals-page.module').then(m => m.GoalsPageModule)
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
