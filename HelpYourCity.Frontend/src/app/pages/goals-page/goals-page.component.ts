import {Component, OnInit} from '@angular/core';
import {IGoal} from '../../models/goal.model';
import {GoalsService} from '../../services/goals.service';

@Component({
  selector: 'app-goals-page',
  templateUrl: './goals-page.component.html',
  styleUrls: ['./goals-page.component.scss']
})
export class GoalsPageComponent implements OnInit {
  goals: IGoal[] | undefined = [];
  constructor(
    readonly goalsService: GoalsService
  ) { }

  async ngOnInit(): Promise<void> {
    this.goals = await this.goalsService.getAll().toPromise();
  }


}
