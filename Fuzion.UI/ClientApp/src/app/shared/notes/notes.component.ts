import { Component, OnInit, Input, SimpleChanges } from '@angular/core';

import { DataService } from '../../core/data.service';
import { ToastrService } from '../../core/toastr.service';
import { IHardwareAdditionalInfo } from '../../shared/interfaces/interfaces';

@Component({
  selector: 'notes',
  templateUrl: './notes.component.html',
})

export class NotesComponent implements OnInit {
  notes: IHardwareAdditionalInfo[] = [];
  @Input() hardwareId: number;

  note: IHardwareAdditionalInfo = {
    body: '',
    createdBy: '',
    createdOn: null
  }

  constructor(private dataService: DataService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getHardwareNotes(this.hardwareId);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.getHardwareNotes(changes.hardwareId.currentValue)
  }

  addNote() {
    this.note.hardwareId = this.hardwareId;
    this.dataService.insertNote(this.note)
      .subscribe((note: IHardwareAdditionalInfo) => {
        this.toastr.success('Note Added', 'Success');
        this.getHardwareNotes(this.hardwareId);
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  getHardwareNotes(id: number) {
    this.dataService.getHardwareNotes(id)
      .subscribe((notes: IHardwareAdditionalInfo[]) =>
        this.notes = notes);
  }
}
