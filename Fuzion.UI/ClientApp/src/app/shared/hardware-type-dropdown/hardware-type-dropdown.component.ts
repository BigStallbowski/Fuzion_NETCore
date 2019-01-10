import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IHardware, IGeneric } from '../interfaces/interfaces';

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
  @Input() inputModel: IHardware;
  @Output() outputModel: EventEmitter<number> = new EventEmitter<number>();

  hardwareTypeList: IGeneric[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getHardwareTypeList();
  }

  onHardwareTypeChange($event) {
    this.outputModel.emit($event.id);
  }

  getHardwareTypeList() {
    this.dataService.getHardwareTypeList().subscribe((hardwareTypes: IGeneric[]) => this.hardwareTypeList = hardwareTypes);
  }
}
