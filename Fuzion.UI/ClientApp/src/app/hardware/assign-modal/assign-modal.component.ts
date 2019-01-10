import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

import { IHardware } from '../../shared/interfaces/interfaces';
import { DataService } from '../../core/data.service';
import { ToastrService } from '../../core/toastr.service';

@Component({
  selector: 'assign-modal',
  templateUrl: './assign-modal.component.html',
})

export class AssignModalComponent implements OnInit {
  @Input() inputModel: IHardware;

  constructor(public activeModal: NgbActiveModal,
    private dataService: DataService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit() {
  }

  assign() {
    this.dataService.assignHardware(this.inputModel)
      .subscribe((hardware: IHardware) => {
        this.activeModal.close();
        this.router.navigate(['hardware/' + this.inputModel.id]);
        this.toastr.success('Device assigned', 'Success');
      },
        (err: any) => {
          console.log(err);
          this.toastr.error(err, 'Error');
        });
  }

  closeModal() {
    this.activeModal.close();
  }

  onPurposeChange(e: number) {
    this.inputModel.purposeId = e;
  }
}
