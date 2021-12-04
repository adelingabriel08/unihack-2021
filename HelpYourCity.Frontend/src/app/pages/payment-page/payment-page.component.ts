import { Component, OnInit } from '@angular/core';
import {loadStripe, RedirectToCheckoutOptions, Stripe, StripeElementsOptions} from '@stripe/stripe-js';


@Component({
  selector: 'app-payment-page',
  templateUrl: './payment-page.component.html',
  styleUrls: ['./payment-page.component.scss']
})
export class PaymentPageComponent implements OnInit {

  public paymentUrl: string;
  private _stripe: Stripe | null;
  private _stripeOptions: RedirectToCheckoutOptions = {
    successUrl: 'http://google.com',
    cancelUrl: 'http://localhost:4200/payment',
    lineItems: [{ price: 'price_1K2x5oLZUCeOGRZpWeZPKbqx', quantity: 5}],
    mode: 'payment',
    customerEmail: 'email@testemail.com',
    submitType: 'pay'
  };

  constructor() {
  }

  async ngOnInit(): Promise<void> {
    this._stripe = await loadStripe('pk_test_51K2lr8LZUCeOGRZpUTKdOEQwbl5g7zhsamA4HYmhwQKWXvYdQ3dyPp5VifstxUwzuMDUCiEtrf3W23h2p6wVuKt000RVSqDCal');
  }

  redirectToCheckout() : void {
     console.log('clicked');
    this._stripe?.redirectToCheckout(this._stripeOptions);
  }

}
