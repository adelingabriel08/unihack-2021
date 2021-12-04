import { Component, OnInit } from '@angular/core';
import {loadStripe, RedirectToCheckoutOptions, Stripe, StripeElementsOptions} from '@stripe/stripe-js';
import {HttpClient} from "@angular/common/http";


@Component({
  selector: 'app-payment-page',
  templateUrl: './payment-page.component.html',
  styleUrls: ['./payment-page.component.scss']
})
export class PaymentPageComponent implements OnInit {

  private _stripe: Stripe | null;
  private _stripeOptions: RedirectToCheckoutOptions;

  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {

  }

  async redirectToCheckout() : Promise<void> {
    var body = {
      email: "customerEmail@email.com",
      quantity: 3,
      firstName: "Mos",
      lastName: "Craciun",
      message: "This is a message",
      isAnnonymous: false,
      goalId: 1
    };
    this._stripe = await loadStripe('pk_test_51K2lr8LZUCeOGRZpUTKdOEQwbl5g7zhsamA4HYmhwQKWXvYdQ3dyPp5VifstxUwzuMDUCiEtrf3W23h2p6wVuKt000RVSqDCal');
    await this.httpClient.post<RedirectToCheckoutOptions>('https://localhost:7120/api/payment/GetOptions', body).subscribe(
      res => {
        this._stripeOptions = res;

        this._stripe?.redirectToCheckout(this._stripeOptions);
      });
  }
}
