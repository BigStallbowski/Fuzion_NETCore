import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
import { ChartType, ChartEvent } from "ng-chartist/dist/chartist.component";

import { DataService } from '../core/data.service';
import { IHardwareCounts } from '../shared/interfaces/interfaces';

const data: any = require('../shared/data/chartist.json');

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

  DonutChart: Chart = {
    type: 'Pie',
    data: data['donutDashboard'],
    options: {
        donut: true,
        startAngle: 310,
        donutSolid: true,
        donutWidth: 30,
        labelInterpolationFnc: function (value) {
            var total = data['donutDashboard'].series.reduce(function (prev, series) {
                return prev + series.value;
            }, 0);
            return total + '%';
        }
    },
    events: {
        created(data: any): void {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'donutGradient1',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(155, 60, 183,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(255, 57, 111, 1)'
            });
            defs.elem('linearGradient', {
                id: 'donutGradient2',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 75, 145,0.8)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(120, 204, 55, 0.8)'
            });

            defs.elem('linearGradient', {
                id: 'donutGradient3',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(132, 60, 247,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(56, 184, 242, 1)'
            });

        },
        draw(data: any): void {
            if (data.type === 'label') {
                if (data.index === 0) {
                    data.element.attr({
                        dx: data.element.root().width() / 2,
                        dy: data.element.root().height() / 2
                    });
                } else {
                    data.element.remove();
                }
            }

        }
    }
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
