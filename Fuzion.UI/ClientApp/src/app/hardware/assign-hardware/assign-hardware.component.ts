import { Component , OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { DataService } from '../../core/data.service';
import { IHardware, IList } from '../../shared/interfaces/interfaces';

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
        purposeId: 0,
        isAssigned: 0,
        isRetired: 0
    };

    hardwareList: IHardware[];
    hardwareTypeList: IList[];
    manufacturerList: IList[];
    modelList: IList[];
    operatingSystemList: IList[];
    purposeList: IList[];

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    ngOnInit() {
        this.getHardwareList();
        this.getHardwareTypeList();
        this.getManufacturerList();
        this.getModelList();
        this.getOperatingSystemList();
        this.getPurposeList();
    }

    onHardwareChange($event) {
        console.log($event.assetNumber);
    }

    onHardwareClear() {
        console.log("Cleared");
    }

    getHardwareList() {
        this.dataService.getHardwareList().subscribe((hw: IHardware[]) => this.hardwareList = hw);
    }

    getHardwareTypeList() {
        this.dataService.getHardwareTypeList().subscribe((hardwareTypes: IList[]) => this.hardwareTypeList = hardwareTypes);
    }

    getManufacturerList() {
        this.dataService.getManufacturerList().subscribe((manufacturers: IList[]) => this.manufacturerList = manufacturers);
    }

    getModelList() {
        this.dataService.getModelList().subscribe((models: IList[]) => this.modelList = models);
    }

    getOperatingSystemList() {
        this.dataService.getOperatingSystemList().subscribe((operatingSystems: IList[]) => this.operatingSystemList = operatingSystems);
    }

    getPurposeList() {
        this.dataService.getPurposeList().subscribe((purposes: IList[]) => this.purposeList = purposes);
    }

    submit() {
            this.dataService.assignHardware(this.hardware)
                .subscribe((hardware: IHardware) => {

                },
                (err: any) => console.log(err));
        
    }
}