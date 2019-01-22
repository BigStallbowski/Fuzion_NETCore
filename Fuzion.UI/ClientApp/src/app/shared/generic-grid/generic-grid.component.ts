import { Component, Input, OnInit, ViewChild} from '@angular/core';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GenericDataService } from '../../core/services/generic-data.service';
import { ToastrService } from '../../core/toastr.service';
import { IGeneric } from '../interfaces/interfaces';

@Component({
  selector: 'generic-grid',
  templateUrl: './generic-grid.component.html',
  styleUrls: ['./generic-grid.component.scss']
})
export class GenericGridComponent implements OnInit{
  @Input() genericType: string;

  genericTypeObject: IGeneric = {
    name: ''
  };
  editing = {};
  rowData: IGeneric[];
  tempRowData: IGeneric[];

  @ViewChild(DatatableComponent) table: DatatableComponent;

  constructor(private data: GenericDataService, private toastr: ToastrService) {
  }

  ngOnInit(){
    console.log(this.genericType);
    this.getGenericTypeList().subscribe(hardwareTypes => this.tempRowData = hardwareTypes)
    this.getGenericTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes)
  }

  addGenericType() {
    this.data.insertGenericType(this.genericType, this.genericTypeObject)
      .subscribe(() => {
        this.genericTypeObject = { name: '' };
        this.getGenericTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes);
        this.toastr.success('Device Type Added', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  deleteGenericType(value) {
    this.data.deleteGenericType(this.genericType, value.id)
      .subscribe(() => {
        this.getGenericTypeList().subscribe(hardwareTypes => this.rowData = hardwareTypes);
        this.toastr.success('Device Type Deleted', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  getGenericTypeList(): Observable<IGeneric[]> {
    return this.data.getGenericTypeList(this.genericType);
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
    this.genericTypeObject = {
      id: value.id,
      name: event.target.value
    };
    this.editing[rowIndex + '-' + cell] = false;
    this.data.updateGenericType(this.genericType, this.genericTypeObject)
      .subscribe(() => {
        this.genericTypeObject = { name: '' };
        this.rowData[rowIndex][cell] = event.target.value;
        this.toastr.success('Device Type Updated', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }
}
