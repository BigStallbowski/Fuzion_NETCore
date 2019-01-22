import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IGeneric, IGenericResponse } from '../../shared/interfaces/interfaces';
import { environment } from '../../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})

export class GenericDataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  deleteGenericType(genericType: string, id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + `${genericType}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getGenericTypeList(genericType: string): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + `${genericType}`)
      .pipe(
        map(hardwareTypeList => {
          return hardwareTypeList;
        }),
        catchError(this.handleError)
      );
  }

  insertGenericType(genericType: string, genericTypeItem: IGeneric): Observable<IGeneric> {
    return this.http.post<IGenericResponse>(this.baseUrl + `${genericType}`, genericTypeItem)
      .pipe(
        map(data => {
          return data.model;
        }),
        catchError(this.handleError)
      )
  }

  updateGenericType(genericType: string, genericTypeItem: IGeneric): Observable<IGeneric> {
    return this.http.put<IGenericResponse>(this.baseUrl + `${genericType}/${genericTypeItem.id}`, genericTypeItem)
      .pipe(
        map(data => {
          return data.model;
        }),
        catchError(this.handleError)
      )
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
