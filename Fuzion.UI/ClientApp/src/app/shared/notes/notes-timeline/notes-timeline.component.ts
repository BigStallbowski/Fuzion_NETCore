import { Component, Input, OnInit } from '@angular/core';

import { DataService } from '../../../core/data.service';
import { ToastrService } from '../../../core/toastr.service';
import { IHardwareAdditionalInfo } from '../../interfaces/interfaces';

@Component({
  selector: 'notes-timeline',
  templateUrl: './notes-timeline.component.html',
})

export class NotesTimelineComponent implements OnInit {
  @Input() notes: IHardwareAdditionalInfo[] = [];

  note: IHardwareAdditionalInfo = {
    body: '',
    createdBy: '',
    createdOn: null
  };

  constructor(private dataService: DataService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  deleteNote(id: number) {
    this.dataService.deleteNote(id)
      .subscribe((res: any) => {
        this.notes.pop();
        this.toastr.success('Note deleted', 'Success');
      },
        error => {
          this.toastr.error('Error: ' + error, 'Error');
        });
  }
}
