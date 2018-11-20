import { Component , OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { DataService } from '../../core/data.service';
import { IHardware, IHardwareList } from '../../shared/interfaces/interfaces';

@Component({
    selector: 'assign-hardware',
    templateUrl: './assign-hardware.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class AssignHardwareComponent implements OnInit {

    hardware: IHardware = {
        assetNumber: '',
        serialNumber: '',
        assignedTo: '',
        hardwareTypeId: 0,
        manufacturerId: 0,
        modelId: 0,
        osId: 0,
        purposeId: 0,
        isAssigned: 0,
        isRetired: 0
    };

    hardwareList: IHardwareList[];

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    ngOnInit() {
        this.getHardwareList();
    }

    onHardwareChange($event) {
        console.log($event.assetNumber);
    }

    onHardwareClear() {
        console.log("Cleared");
    }

    getHardwareList() {
        this.dataService.getHardwareList().subscribe((hw: IHardwareList[]) => this.hardwareList = hw);
    }
}