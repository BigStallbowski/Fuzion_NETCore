import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IList } from '../interfaces/interfaces';

@Component({
    selector: 'models',
    templateUrl: './model-dropdown.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ]
})

export class ModelDropdownComponent implements OnInit {
    @Input() inputModel: any;

    modelList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getModelList();
    }

    getModelList() {
        this.dataService.getModelList().subscribe((models: IList[]) => this.modelList = models);
    }
}
