import { Component, OnInit } from '@angular/core';

import { DataService } from '../core/data.service';
import { ICount } from '../shared/interfaces/interfaces';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
  totalHardwareCount: ICount;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getTotalHardwareCount();
  }

  getTotalHardwareCount() {
    this.dataService.getTotalHardwareCount()
      .subscribe((response: ICount) => {
        this.totalHardwareCount = response;
      },
      (err: any) => console.log(err),
      () => console.log('getTotalHardwareCount() retrieved count'));
  }
}
