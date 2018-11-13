import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ICount } from '../shared/interfaces/interfaces';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTotalHardwareCount(): Observable<ICount> {
    return this.http.get<ICount>(this.baseUrl + 'hardware/totalhardwarecount')
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'Opps. Broken');
  }
}
