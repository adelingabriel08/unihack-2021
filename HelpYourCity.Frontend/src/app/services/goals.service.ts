import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IGoal} from '../models/goal.model';

@Injectable({
  providedIn: 'root'
})
export class GoalsService {
  readonly baseUrl = environment.apiUrl + '/api/goals';

  constructor(
    private readonly _http: HttpClient
  ) { }


  getAll(): Observable<IGoal[]> {
    return this._http.get<IGoal[]>(this.baseUrl);
  }

  getBySlug(slug: string): Observable<IGoal> {
    const url = this.baseUrl + `/${slug}`;
    return this._http.get<IGoal>(url);
  }
}
