import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList } from '../interfaces/interfaces';

@Component({
    selector: 'hardware-types',
    templateUrl: './hardware-type-dropdown.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class HardwareTypeDropdownComponent implements OnInit {
    
    @Input() inputModel: any;

    hardwareTypeList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getHardwareTypeList();
    }

    getHardwareTypeList() {
        this.dataService.getHardwareTypeList().subscribe((hardwareTypes: IList[]) => this.hardwareTypeList = hardwareTypes);
    }
}