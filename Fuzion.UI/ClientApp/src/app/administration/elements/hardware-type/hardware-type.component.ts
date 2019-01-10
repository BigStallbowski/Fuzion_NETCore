import { Component, ViewChild } from '@angular/core';
import { DatatableComponent } from '@swimlane/ngx-datatable';

import { DataService } from '../../../core/data.service';
import { ToastrService } from '../../../core/toastr.service';
import { IGeneric } from '../../../shared/interfaces/interfaces';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-hardware-type',
  templateUrl: './hardware-type.component.html',
  styleUrls: []
})

export class HardwareTypeComponent {
  hardwareType: IGeneric = {
    name: ''
  };
  editing = {};
  rowData: IGeneric[];
  tempRowData: IGeneric[];

  @ViewChild(DatatableComponent) table: DatatableComponent;

  constructor(private dataService: DataService, private toastr: ToastrService) {
    this.getHardwareTypeList().subscribe(hardwareTypes => this.tempRowData = hardwareTypes)
    this.getHardwareTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes)
  }

  addHardwareType() {
    this.dataService.insertHardwareType(this.hardwareType)
      .subscribe(() => {
        this.hardwareType = { name: '' };
        this.getHardwareTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes);
        this.toastr.success('Device Type Added', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  deleteDeviceType(value) {
    this.dataService.deleteHardwareType(value.id)
      .subscribe(() => {
        this.getHardwareTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes);
        this.toastr.success('Device Type Deleted', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  getHardwareTypeList(): Observable<IGeneric[]> {
    return this.dataService.getHardwareTypeList();
  }

  updateFilter(event) {
    const val = event.target.value.toLowerCase();
    const temp = this.tempRowData.filter(function (d) {
      return d.name.toLowerCase().indexOf(val) !== -1 || !val;
    });
    this.rowData = temp;
    this.table.offset = 0;
  }

  updateValue(event, cell, rowIndex, value) {
    this.hardwareType = {
      id: value.id,
      name: event.target.value
    };
    this.editing[rowIndex + '-' + cell] = false;
    this.dataService.updateHardwareType(this.hardwareType)
      .subscribe(() => {
        this.hardwareType = { name: '' };
        this.rowData[rowIndex][cell] = event.target.value;
        this.toastr.success('Device Type Updated', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }
}
