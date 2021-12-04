import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {IFileResponse} from '../models/file-response.model';

@Injectable({
  providedIn: 'root'
})
export class ProposalService {
  readonly baseUrl = environment.apiUrl + '/api/';

  constructor(
    private readonly _http: HttpClient
  ) { }

  uploadFile(file: File): Observable<IFileResponse> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    const url = this.baseUrl + 'content';
    return this._http.post<IFileResponse>(url, formData);
  }
}
