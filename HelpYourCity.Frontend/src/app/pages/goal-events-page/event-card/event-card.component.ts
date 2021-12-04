import {Component, Input, OnInit} from '@angular/core';
import {IVolunteeringEvent} from '../../../models/volunteering-event.model';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.scss']
})
export class EventCardComponent {
  @Input() event: IVolunteeringEvent;
}
