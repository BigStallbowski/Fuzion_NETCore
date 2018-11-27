import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList } from '../interfaces/interfaces';

@Component({
    selector: 'manufacturers',
    templateUrl: './manufacturer-dropdown.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class ManufacturerDropdownComponent implements OnInit {
    
    @Input() inputModel: any;

    manufacturerList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getManufacturerList();
    }

    getManufacturerList() {
        this.dataService.getManufacturerList().subscribe((manufacturers: IList[]) => this.manufacturerList = manufacturers);
    }
}