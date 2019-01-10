import { Component, OnInit, Input, SimpleChanges } from '@angular/core';

import { DataService } from '../../core/data.service';
import { ToastrService } from '../../core/toastr.service';
import { IHardwareAdditionalInfo } from '../../shared/interfaces/interfaces';

@Component({
  selector: 'assignment-history',
  templateUrl: './assignment-history.component.html'
})

export class AssignmentHistoryComponent implements OnInit {
  @Input() hardwareId: number;

  assignmentHistoryList: IHardwareAdditionalInfo[] = [];

  assignmentHistory: IHardwareAdditionalInfo = {
    body: '',
    createdBy: '',
    createdOn: null
  }

  constructor(private dataService: DataService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getHardwareAssignmentHistory(this.hardwareId);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.getHardwareAssignmentHistory(changes.hardwareId.currentValue)
  }

  getHardwareAssignmentHistory(id: number) {
    this.dataService.getHardwareAssignmentHistory(id)
      .subscribe((assignmentHistory: IHardwareAdditionalInfo[]) =>
        this.assignmentHistoryList = assignmentHistory);
  }
}
