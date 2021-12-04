import {IFileResponse} from './file-response.model';

export interface IGoal {
  id: number;
  title: string;
  image: IFileResponse;
  shortDescription: string;
  description: string;
  target: number;
  pricePerUnit: number;
  goalItemName: string;
  slug: string;
  donors: number;
  numberOfDonations: number;
}
