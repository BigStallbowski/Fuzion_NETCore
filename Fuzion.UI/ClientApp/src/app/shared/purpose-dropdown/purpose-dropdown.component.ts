import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

import { DataService } from '../../core/data.service';
import { IHardware, IGeneric } from '../interfaces/interfaces';

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
  @Input() inputModel: IHardware;
  @Output() outputModel: EventEmitter<number> = new EventEmitter<number>();

  purposeList: IGeneric[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getPurposeList();
  }

  onPurposeChange($event) {
    this.outputModel.emit($event.id);
  }

  getPurposeList() {
    this.dataService.getPurposeList().subscribe((purposes: IGeneric[]) => this.purposeList = purposes);
  }
}
