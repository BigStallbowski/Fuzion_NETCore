import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { catchError, map, tap, retry } from 'rxjs/operators';

import { environment } from '../../../environments/environment.prod';
import { IGeneric } from '../../shared/interfaces/interfaces';

const CREATE_ACTION = 'create';
const UPDATE_ACTION = 'update';
const REMOVE_ACTION = 'destroy';

@Injectable()
export class HardwareTypeService extends BehaviorSubject<any[]> {
  constructor(private http: HttpClient) {
    super([]);
  }

  private baseUrl = environment.apiUrl;
  private data: IGeneric[] = [];

  //   insertHardwareType(hardwareType: IGeneric): Observable<IGeneric> {
  //     return this.http.post<IGenericResponse>(this.baseUrl + "hardwaretypes", hardwareType)
  //       .pipe(
  //         map(data => {
  //           return data.model;
  //         }),
  //         catchError(this.handleError)
  //       )
  //   }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'Opps. Broken');
  }

  private serializeModels(data?: any): string {
    return data ? `&models=${JSON.stringify([data])}` : '';
  }
}
