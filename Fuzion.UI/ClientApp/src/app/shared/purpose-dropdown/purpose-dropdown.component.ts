import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList } from '../interfaces/interfaces';

@Component({
    selector: 'purposes',
    templateUrl: './purpose-dropdown.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class PurposeDropdownComponent implements OnInit {
    @Input() inputModel: any;

    purposeList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getPurposeList();
    }

    getPurposeList() {
        this.dataService.getPurposeList().subscribe((purposes: IList[]) => this.purposeList = purposes);
    }
}
