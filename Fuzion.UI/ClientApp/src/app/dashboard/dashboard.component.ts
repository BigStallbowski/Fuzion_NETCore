import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
import { ChartType, ChartEvent } from "ng-chartist/dist/chartist.component";

import { DataService } from '../core/data.service';
import { IHardwareCounts } from '../shared/interfaces/interfaces';

export interface Chart {
  type: ChartType;
  data: Chartist.IChartistData;
  options?: any;
  responsiveOptions?: any;
  events?: ChartEvent;
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
  hardwareCounts: IHardwareCounts = {
    totalAvailableHardware: 0,
    totalDeployedHardware: 0,
    totalAvailableWorkstations: 0,
    totalDeployedWorkstations: 0,
    totalAvailableLaptops: 0,
    totalDeployedLaptops: 0,
    totalAvailableMobileDevices: 0,
    totalDeployedMobileDevices: 0
  };

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getHardwareCounts();
  }

  getHardwareCounts() {
    this.dataService.getHardwareCounts()
      .subscribe((counts: IHardwareCounts) => {
        this.hardwareCounts = counts;
      },
      (err: any) => console.log(err),
      () => console.log('getHardwareCounts() retrieved counts'));
  }
}
