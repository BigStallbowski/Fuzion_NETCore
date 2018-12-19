import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList, IHardware } from '../interfaces/interfaces';

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
    @Input() inputModel: IHardware;
    @Output() outputModel: EventEmitter<number> = new EventEmitter<number>();

    manufacturerList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getManufacturerList();
    }

    onManufacturerChange($event) {
        this.outputModel.emit($event.id);
    }

    getManufacturerList() {
        this.dataService.getManufacturerList().subscribe((manufacturers: IList[]) => this.manufacturerList = manufacturers);
    }
}
