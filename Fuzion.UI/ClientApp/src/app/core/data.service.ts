import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import {
  IHardware,
  IHardwareCounts,
  IHardwareResponse,
  IGeneric,
  IGenericResponse,
  IHardwareAdditionalInfo,
  IHardwareAdditionalInfoResponse
} from '../shared/interfaces/interfaces';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  assignHardware(hardware: IHardware): Observable<IHardware> {
    return this.http.put<IHardwareResponse>(this.baseUrl + 'hardware/' + hardware.id + '/assign', hardware)
      .pipe(
        map((data) => {
          return data.model
        }),
        catchError(this.handleError)
      );
  }

  deleteHardwareType(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + `hardwaretypes/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteNote(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + `notes/${id}`)
      .pipe(
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

  getHardwareDetails(id: number): Observable<IHardware> {
    return this.http.get<IHardware>(this.baseUrl + 'hardware/' + id)
      .pipe(
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

  getHardwareTypeList(): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + 'hardwaretypes')
      .pipe(
        map(hardwareTypeList => {
          return hardwareTypeList;
        }),
        catchError(this.handleError)
      );
  }

  getManufacturerList(): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + 'manufacturers')
      .pipe(
        map(manufacturerList => {
          return manufacturerList;
        }),
        catchError(this.handleError)
      );
  }

  getModelList(): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + 'models')
      .pipe(
        map(modelList => {
          return modelList;
        }),
        catchError(this.handleError)
      );
  }

  getHardwareAssignmentHistory(id: number): Observable<IHardwareAdditionalInfo[]> {
    return this.http.get<IHardwareAdditionalInfo[]>(this.baseUrl + 'assignmenthistory/' + id)
      .pipe(
        map(assignmentHistoryList => {
          return assignmentHistoryList;
        }),
        catchError(this.handleError)
      );
  }

  getHardwareNotes(id: number): Observable<IHardwareAdditionalInfo[]> {
    return this.http.get<IHardwareAdditionalInfo[]>(this.baseUrl + 'notes/' + id)
      .pipe(
        map(noteList => {
          return noteList;
        }),
        catchError(this.handleError)
      );
  }

  getOperatingSystemList(): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + 'operatingsystems')
      .pipe(
        map(operatingSystemList => {
          return operatingSystemList;
        }),
        catchError(this.handleError)
      );
  }

  getPurposeList(): Observable<IGeneric[]> {
    return this.http.get<IGeneric[]>(this.baseUrl + 'purposes')
      .pipe(
        map(operatingSystemList => {
          return operatingSystemList;
        }),
        catchError(this.handleError)
      );
  }

  insertHardware(hardware: IHardware): Observable<IHardware> {
    return this.http.post<IHardwareResponse>(this.baseUrl + 'hardware', hardware)
      .pipe(
        map(data => {
          return data.model;
        }),
        catchError(this.handleError)
      )
  }

  updateHardwareType(hardwareType: IGeneric): Observable<IGeneric> {
    return this.http.put<IGenericResponse>(this.baseUrl + `hardwaretypes/${hardwareType.id}`, hardwareType)
      .pipe(
        map(data => {
          return data.model;
        }),
        catchError(this.handleError)
      )
  }

  insertHardwareType(hardwareType: IGeneric): Observable<IGeneric> {
    return this.http.post<IGenericResponse>(this.baseUrl + "hardwaretypes", hardwareType)
      .pipe(
        map(data => {
          return data.model;
        }),
        catchError(this.handleError)
      )
  }

  insertNote(note: IHardwareAdditionalInfo): Observable<IHardwareAdditionalInfo> {
    return this.http.post<IHardwareAdditionalInfoResponse>(this.baseUrl + 'notes', note)
      .pipe(
        map(data => {
          return data.object;
        }),
        catchError(this.handleError)
      );
  }

  unassignHardware(hardware: IHardware): Observable<IHardware> {
    return this.http.put<IHardwareResponse>(this.baseUrl + 'hardware/' + hardware.id + '/unassign', hardware)
      .pipe(
        map((data) => {
          return data.model
        }),
        catchError(this.handleError)
      );
  }

  calculateHardwareCountsPercentages(hardwareCounts: IHardwareCounts) {
    if (hardwareCounts.totalAvailableHardware != 0 && hardwareCounts.totalDeployedHardware != 0) {
      let percentage = 0;
      percentage = hardwareCounts.totalDeployedHardware / hardwareCounts.totalAvailableHardware;
      hardwareCounts.totalDeployedHardwarePercentage = percentage;
    }

    if (hardwareCounts.totalAvailableWorkstations != 0 && hardwareCounts.totalAvailableWorkstations != 0) {
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
