import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IHardwareCounts, IHardwareList } from '../shared/interfaces/interfaces';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getHardwareCounts(): Observable<IHardwareCounts> {
    return this.http.get<IHardwareCounts>(this.baseUrl + 'hardware/hardwarecounts')
      .pipe(
      map(counts => {
        this.calculateHardwareCountsPercentages(counts);
        return counts;
      }),
        catchError(this.handleError)
      );
  }

  getHardwareList(): Observable<IHardwareList[]> {
    return this.http.get<IHardwareList[]>(this.baseUrl + 'hardware')
      .pipe(
        map(hardwareList => {
          return hardwareList;
        }),
        catchError(this.handleError)
      );
  }

  calculateHardwareCountsPercentages(hardwareCounts: IHardwareCounts)
  {
    if (hardwareCounts.totalAvailableHardware != 0 && hardwareCounts.totalDeployedHardware != 0)
    {
      let percentage = 0;
      percentage = hardwareCounts.totalDeployedHardware / hardwareCounts.totalAvailableHardware;
      hardwareCounts.totalDeployedHardwarePercentage = percentage;
    }

    if (hardwareCounts.totalAvailableWorkstations != 0 && hardwareCounts.totalAvailableWorkstations != 0)
    {
      let percentage = 0;
      percentage = hardwareCounts.totalDeployedWorkstations / hardwareCounts.totalAvailableWorkstations;
      hardwareCounts.totalDeployedHardwarePercentage = percentage;
    }
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
