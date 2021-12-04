import {Component} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-payment-failure-page',
  templateUrl: './payment-failure-page.component.html',
  styleUrls: ['./payment-failure-page.component.scss']
})
export class PaymentFailurePageComponent {
  constructor(
    readonly router: Router
  ) {
  }
}
