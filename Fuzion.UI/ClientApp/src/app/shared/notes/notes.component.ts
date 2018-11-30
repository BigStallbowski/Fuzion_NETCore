import { Component, OnInit, Input } from '@angular/core';

import { DataService } from '../../core/data.service';
import { ToastrService } from '../../core/toastr.service';
import { INote } from '../../shared/interfaces/interfaces';

@Component({
    selector: 'notes',
    templateUrl: './notes.component.html',
})

export class NotesComponent implements OnInit {
    notes: INote[] = [];
    @Input() hardwareId: number;

    note: INote = {
        body: '',
        createdBy: '',
        createdOn: null
    }

    constructor(private dataService: DataService, private toastr: ToastrService) { }

    ngOnInit() {
        this.getHardwareNotes(this.hardwareId);
    }

    addNote() {
        this.note.hardwareId = this.hardwareId;
        this.dataService.insertNote(this.note)
            .subscribe((note: INote) => {
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
            .subscribe((notes: INote[]) =>
            this.notes = notes);
    }
}