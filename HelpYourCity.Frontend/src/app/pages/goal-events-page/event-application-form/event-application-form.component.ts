import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {IGoal} from '../../../models/goal.model';
import {IVolunteeringEvent} from '../../../models/volunteering-event.model';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {GoalsService} from '../../../services/goals.service';
import {IVolunteer} from '../../../models/volunteer.model';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-event-application-form',
  templateUrl: './event-application-form.component.html',
  styleUrls: ['./event-application-form.component.scss']
})
export class EventApplicationFormComponent {
  form: FormGroup = this._formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required]]
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { goal: IGoal, event: IVolunteeringEvent },
    private readonly _snack: MatSnackBar,
    private readonly _formBuilder: FormBuilder,
    private readonly _goalsService: GoalsService
  ) {
  }

  async submit(): Promise<void> {
    const volunteer: IVolunteer = {...this.form.value, eventId: this.data.event.id, goalId: this.data.goal.id};
    try {
      this.form.reset();
      await this._goalsService.volunteer(volunteer).toPromise();
      this._snack.open('Volunteering application sent successfully!');
    } catch (err: any) {
      this._snack.open(err.error, 'Close');
    }
  }
}
