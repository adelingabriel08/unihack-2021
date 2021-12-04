import {Component} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-payment-succes-page',
  templateUrl: './payment-succes-page.component.html',
  styleUrls: ['./payment-succes-page.component.scss']
})
export class PaymentSuccesPageComponent {
  constructor(
    readonly router: Router
  ) {
  }
}
