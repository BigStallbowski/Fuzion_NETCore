import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList } from '../interfaces/interfaces';

@Component({
    selector: 'operating-systems',
    templateUrl: './operating-system-dropdown.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class OperatingSystemDropdownComponent implements OnInit {
    
    @Input() inputModel: any;

    operatingSystemList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getOperatingSystemList();
    }

    getOperatingSystemList() {
        this.dataService.getOperatingSystemList().subscribe((operatingSystems: IList[]) => this.operatingSystemList = operatingSystems);
    }
}