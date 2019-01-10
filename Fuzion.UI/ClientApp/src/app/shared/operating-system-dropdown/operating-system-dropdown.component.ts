import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IHardware, IGeneric } from '../interfaces/interfaces';

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
  @Input() inputModel: IHardware;
  @Output() outputModel: EventEmitter<number> = new EventEmitter<number>();

  operatingSystemList: IGeneric[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getOperatingSystemList();
  }

  onOperatingSystemChange($event) {
    this.outputModel.emit($event.id);
  }

  getOperatingSystemList() {
    this.dataService.getOperatingSystemList().subscribe((operatingSystems: IGeneric[]) => this.operatingSystemList = operatingSystems);
  }
}
