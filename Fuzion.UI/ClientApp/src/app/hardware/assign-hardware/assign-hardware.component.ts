import { Component , OnInit } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { Router, ActivatedRoute } from '@angular/router';

import { DataService } from '../../core/data.service';
import { ToastrService } from '../../core/toastr.service';
import { IHardware, INote } from '../../shared/interfaces/interfaces';

@Component({
    selector: 'assign-hardware',
    templateUrl: './assign-hardware.component.html',
    styles: [
        `
        .form-control.ng-select {
            padding: 0;
            border: none;
          }
        `
    ],
    animations: [
        trigger('fadeInOut', [
            state('void', style({
                opacity: 0
            })),
            transition('void <=> *', animate(1000))
        ]),
        trigger('enterLeave', [
            state('flyIn', style({ transform: 'translateX(-200%)'})),
            transition(':enter', [
                style({ transform: 'translate(100%)' }),
                animate('0.3s ease-in')
            ]),
            transition(':leave', [
                animate('0.3s ease-out', style({ transform: 'translate(100%)'}))
            ])
        ])
    ]
})

export class AssignHardwareComponent implements OnInit {
    hardware: IHardware = {
        assetNumber: '',
        serialNumber: '',
        assignedTo: '',
        purposeId: 0,
        isAssigned: 0,
        isRetired: 0
    };

    hardwareList: IHardware[];
    noteList: INote[];

    showHardwareInfo: boolean;
    showUnassign: boolean;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService,
        private toastr: ToastrService) { }

    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        if (typeof id !== 'undefined') {
            this.getAssignedHardware(id);
            this.getHardwareList();
            this.showHardwareInfo = true;
            this.showUnassign = true;
        } else {
            this.getUnassignedHardware();
            this.showHardwareInfo = false;
            this.showUnassign = false;
        }
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/']);
    }

    onHardwareChange($event) {
        if (typeof $event != 'undefined')
        {
            console.log($event.id);
            this.dataService.getHardwareDetails($event.id)
            .subscribe((hardware: IHardware) => {
                this.hardware = hardware;
                this.hardware.assetNumber = $event.assetNumber;
                this.showHardwareInfo = true;
            },
            (err: any) => console.log(err));
        } else {
            this.showHardwareInfo = false;
            this.hardware.assetNumber = '';
            this.hardware.assignedTo = '';
        }
    }

    getAssignedHardware(id: number) {
        this.dataService.getHardwareDetails(id)
            .subscribe((hardware: IHardware) => {
                this.hardware = hardware;
            },
            (err: any) => console.log(err));
    }

    getHardwareList() {
        this.dataService.getHardwareList().subscribe((hw: IHardware[]) =>
            this.hardwareList = hw);
    }

    getUnassignedHardware() {
        this.dataService.getHardwareList().subscribe((hw: IHardware[]) =>
            this.hardwareList = hw.filter(unassigned => unassigned.isAssigned == 0));
    }

    submit() {
            this.dataService.assignHardware(this.hardware)
                .subscribe((hardware: IHardware) => {
                    this.toastr.success('Device assigned', 'Success');
                },
                (err: any) => {
                    console.log(err);
                    this.toastr.error(err, 'Error');
                });
    }
}
