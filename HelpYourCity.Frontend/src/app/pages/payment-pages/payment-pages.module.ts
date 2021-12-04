import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentSuccesPageComponent } from './payment-succes-page/payment-succes-page.component';
import { PaymentFailurePageComponent } from './payment-failure-page/payment-failure-page.component';
import {RouterModule, Routes} from '@angular/router';
import {SharedModule} from '../../shared/shared.module';

const routes: Routes = [
  {path: 'success', component: PaymentSuccesPageComponent},
  {path: 'failure', component: PaymentFailurePageComponent}
]

@NgModule({
  declarations: [
    PaymentSuccesPageComponent,
    PaymentFailurePageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class PaymentPagesModule { }
