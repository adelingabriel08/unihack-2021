import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {GoalsService} from '../../services/goals.service';
import {IGoal} from '../../models/goal.model';
import {IVolunteeringEvent} from '../../models/volunteering-event.model';
import {MatDialog} from '@angular/material/dialog';
import {EventApplicationFormComponent} from './event-application-form/event-application-form.component';

@Component({
  selector: 'app-goal-events-page',
  templateUrl: './goal-events-page.component.html',
  styleUrls: ['./goal-events-page.component.scss']
})
export class GoalEventsPageComponent implements OnInit {
  volunteeringEvents: IVolunteeringEvent[];
  goal: IGoal;

  constructor(
    private readonly _route: ActivatedRoute,
    private readonly _goalsService: GoalsService,
  ) { }

  ngOnInit(): void {
    const slug = this._route.snapshot.paramMap.get('slug');
    this._goalsService.getBySlug(slug!).subscribe(res => {
      this.goal = res;
      this._goalsService.getVolunteeringEvents(this.goal.id).subscribe(events => {
        this.volunteeringEvents = events;
      });
    });
  }
}
