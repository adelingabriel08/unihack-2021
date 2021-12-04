import {Component, Input} from '@angular/core';
import {IVolunteeringEvent} from '../../../models/volunteering-event.model';
import {EventApplicationFormComponent} from '../event-application-form/event-application-form.component';
import {MatDialog} from '@angular/material/dialog';
import {IGoal} from '../../../models/goal.model';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.scss']
})
export class EventCardComponent {
  @Input() event: IVolunteeringEvent;
  @Input() goal: IGoal;

  constructor(
    private readonly _dialog: MatDialog
  ) {
  }

  openDialog(): void {
    this._dialog.open(EventApplicationFormComponent, {
      data: {
        goal: this.goal,
        event: this.event
      }
    });
  }
}
