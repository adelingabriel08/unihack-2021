import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {loadStripe, RedirectToCheckoutOptions, Stripe} from '@stripe/stripe-js';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {IDonor} from '../models/donor.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private _stripe: Stripe | null;
  private _stripeOptions: RedirectToCheckoutOptions;
  readonly baseUrl = environment.apiUrl + '/api/payment';

  constructor(
    private readonly _http: HttpClient
  ) { }

  private _getOptions(donor: IDonor): Observable<RedirectToCheckoutOptions> {
    const url = this.baseUrl + '/GetOptions';
    return this._http.post<RedirectToCheckoutOptions>(url, donor);
  }

  async redirectToCheckout(donor: IDonor): Promise<void> {
    const stripeKey = 'pk_test_51K2lr8LZUCeOGRZpUTKdOEQwbl5g7zhsamA4HYmhwQKWXvYdQ3dyPp5VifstxUwzuMDUCiEtrf3W23h2p6wVuKt000RVSqDCal';
    this._stripe = await loadStripe(stripeKey);
    this._getOptions(donor).subscribe(res => {
      this._stripeOptions = res;
      this._stripe?.redirectToCheckout(this._stripeOptions);
    })
  }
}
