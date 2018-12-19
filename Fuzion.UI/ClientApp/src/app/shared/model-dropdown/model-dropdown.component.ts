import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IHardware, IList } from '../interfaces/interfaces';

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
    @Input() inputModel: IHardware;
    @Output() outputModel: EventEmitter<number> = new EventEmitter<number>();

    modelList: IList[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.getModelList();
    }

    onModelChange($event) {
        this.outputModel.emit($event.id);
    }

    getModelList() {
        this.dataService.getModelList().subscribe((models: IList[]) => this.modelList = models);
    }
}
