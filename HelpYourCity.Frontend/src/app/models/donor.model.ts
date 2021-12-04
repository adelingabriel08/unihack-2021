export interface IDonor {
  email: string;
  quantity: number;
  firstName: string;
  lastName: string;
  message: string
  isAnnonymous: boolean;
  goalId: number;
}
