import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IHardware, IHardwareCounts, IHardwareResponse, IList } from '../shared/interfaces/interfaces';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  assignHardware(hardware: IHardware) : Observable<IHardware> {
    return this.http.put<IHardwareResponse>(this.baseUrl + 'hardware/' + hardware.id + '/assign', hardware)
      .pipe(
        map((data) => {
          console.log('assignHardware status: ' + data.status);
          return data.hardware
        }),
        catchError(this.handleError)
      );
  }

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

  getHardwareList(): Observable<IHardware[]> {
    return this.http.get<IHardware[]>(this.baseUrl + 'hardware')
      .pipe(
        map(hardwareList => {
          return hardwareList;
        }),
        catchError(this.handleError)
      );
  }

  getHardwareTypeList(): Observable<IList[]> {
    return this.http.get<IList[]>(this.baseUrl + 'hardwaretypes')
      .pipe(
        map(hardwareTypeList => {
          return hardwareTypeList;
        }),
        catchError(this.handleError)
      );
  }

  getManufacturerList(): Observable<IList[]> {
    return this.http.get<IList[]>(this.baseUrl + 'manufacturers')
      .pipe(
        map(manufacturerList => {
          return manufacturerList;
        }),
        catchError(this.handleError)
      );
  }

  getModelList(): Observable<IList[]> {
    return this.http.get<IList[]>(this.baseUrl + 'models')
      .pipe(
        map(modelList => {
          return modelList;
        }),
        catchError(this.handleError)
      );
  }

  getOperatingSystemList(): Observable<IList[]> {
    return this.http.get<IList[]>(this.baseUrl + 'operatingsystems')
      .pipe(
        map(operatingSystemList => {
          return operatingSystemList;
        }),
        catchError(this.handleError)
      );
  }

  getPurposeList(): Observable<IList[]> {
    return this.http.get<IList[]>(this.baseUrl + 'purposes')
      .pipe(
        map(operatingSystemList => {
          return operatingSystemList;
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
