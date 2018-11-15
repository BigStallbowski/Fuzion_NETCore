import { Component, OnInit } from '@angular/core';

import { DataService } from '../core/data.service';
import { ITotalAvailableCount, ITotalDeployedCount } from '../shared/interfaces/interfaces';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
  totalHardwareCount: ITotalAvailableCount = {
    totalAvailableHardware: 0,
    totalAvailableWorkstations: 0,
    totalAvailableLaptops: 0,
    totalAvailableMobileDevices: 0
  };

  totalDeployedCount: ITotalDeployedCount = {
    totalDeployedHardware: 0,
    totalDeployedWorkstations: 0,
    totalDeployedLaptops: 0,
    totalDeployedMobileDevices: 0
  }

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getTotalHardwareCount();
    this.getTotalDeployedCount();
  }

  getTotalHardwareCount() {
    this.dataService.getTotalAvailableHardwareCount()
      .subscribe((totalHardwareCount: ITotalAvailableCount) => {
        this.totalHardwareCount = totalHardwareCount;
      },
      (err: any) => console.log(err),
      () => console.log('getTotalHardwareCount() retrieved count'));
  }

  getTotalDeployedCount() {
    this.dataService.getTotalDeployedCount()
      .subscribe((totalDeployedCount: ITotalDeployedCount) => {
        this.totalDeployedCount = totalDeployedCount;
      },
      (err: any) => console.log(err),
      () => console.log('getTotalDeployedCount() retrieved count'));
  }
}
