import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ITotalAvailableCount, ITotalDeployedCount } from '../shared/interfaces/interfaces';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTotalAvailableHardwareCount(): Observable<ITotalAvailableCount> {
    return this.http.get<ITotalAvailableCount>(this.baseUrl + 'hardware/totalhardwarecount')
      .pipe(
      map(availableCounts => {
        return availableCounts;
      }),
        catchError(this.handleError)
      );
  }

  getTotalDeployedCount(): Observable<ITotalDeployedCount> {
    return this.http.get<ITotalDeployedCount>(this.baseUrl + 'hardware/totaldeployedcount')
      .pipe(
        map(totalDeployed => {
          return totalDeployed;
        }),
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
