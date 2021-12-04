import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {IGoal} from '../../../models/goal.model';
import {PaymentService} from '../../../services/payment.service';
import {IDonor} from '../../../models/donor.model';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-payment-form',
  templateUrl: './payment-form.component.html',
  styleUrls: ['./payment-form.component.scss']
})
export class PaymentFormComponent {
  form: FormGroup = this._formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    message: ['', [Validators.required]],
    isAnnonymous: [false]
  });
  loading = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { quantity: number, goal: IGoal },
    private readonly _formBuilder: FormBuilder,
    private readonly _paymentService: PaymentService,
    private readonly _snack: MatSnackBar
  ) { }

  async submit(): Promise<void> {
    const donor: IDonor = {...this.form.value, quantity: this.data.quantity, goalId: this.data.goal.id};
    try {
      this.loading = false;
      await this._paymentService.redirectToCheckout(donor);
      this.loading = true;
    } catch (err: any) {
      this._snack.open(err.error, 'Close');
    }
  }
}
