import {IGoal} from './goal.model';

export interface IProposal {
  email: string;
  phone: string;
  firstName: string;
  lastName: string;
  companyName: string;
  goal: IGoal;
}
