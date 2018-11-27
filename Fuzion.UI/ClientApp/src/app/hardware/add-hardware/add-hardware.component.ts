import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { DataService } from '../../core/data.service';
import { IHardware, IList } from '../../shared/interfaces/interfaces';

@Component({
    selector: 'add-hardware',
    templateUrl: './add-hardware.component.html'
})

export class AddHardwareComponent implements OnInit {

    hardware: IHardware = {
        assetNumber: '',
        serialNumber: ''
    };

    hardwareTypeList: IList[];
    manufacturerList: IList[];
    modelList: IList[];
    operatingSystemList: IList[];

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    ngOnInit() {
        this.getHardwareTypeList();
        this.getManufacturerList();
        this.getModelList();
        this.getOperatingSystemList();
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/']);
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
}