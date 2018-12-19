import { Component , OnInit } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { DataService } from '../core/data.service';
import { ToastrService } from '../core/toastr.service';
import { IHardware, IHardwareAdditionalInfo } from '../shared/interfaces/interfaces';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AssignModalComponent } from './assign-modal/assign-modal.component';
import { Subject } from 'rxjs';

@Component({
    selector: 'assign-hardware',
    templateUrl: './hardware.component.html',
    styleUrls: ['./hardware.component.css'],
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

export class HardwareComponent implements OnInit {
    hardware: IHardware = {
    };

    assignmentHistory: IHardwareAdditionalInfo = {
        body: '',
        createdBy: '',
        createdOn: null
    };

    hardwareList: IHardware[];
    noteList: IHardwareAdditionalInfo[];

    assetNumberText: boolean;
    assetNumberInputReadOnly: boolean;
    formTitle: string;
    saveButtonText: string;
    isAssigned: number;
    showAdditionalHardwareInfo: boolean;
    showHardwareInfo: boolean;
    showAssign: boolean;
    showUserInfo: boolean;
    showAdditionalUserInfo: boolean;

    inputModelChange = new Subject<number>();

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService,
        private toastr: ToastrService,
        private modalService: NgbModal) { 
            this.router.routeReuseStrategy.shouldReuseRoute = function () {
                return false;
              };
              
              this.router.events.subscribe((evt) => {
                if (evt instanceof NavigationEnd) {
                  this.router.navigated = false;
                  window.scrollTo(0, 0);
                }
              });
        }

    ngOnInit() {
        console.log(this.router.url)
        let id = this.route.snapshot.params['id'];
        if (this.router.url == '/hardware/add')
        {
            this.buildAddHardwareForm();
            return
        } 
        if (typeof id !== 'undefined')
        {
            this.assetNumberText = true;
            this.assetNumberInputReadOnly = true;
            this.getHardwareList();
            this.getHardwareDetails(id);
            this.formTitle = "Device Details"
            this.showHardwareInfo = true
            this.showAdditionalHardwareInfo = true;
            return;
        }

        this.getUnassignedHardware();
        this.showHardwareInfo = false;
        this.formTitle = "Device Details"
    }

    buildAddHardwareForm()
    {
        this.formTitle = "Add Device"
        this.assetNumberText = true;
        this.showHardwareInfo = true;
        this.showUserInfo = false;
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/']);
    }

    onHardwareChange($event) {
        if (typeof $event != 'undefined')
        {
            this.dataService.getHardwareDetails($event.id)
            .subscribe((hardware: IHardware) => {
                this.hardware = hardware;
                this.hardware.assetNumber = $event.assetNumber;
                this.showHardwareInfo = true;
                this.showAdditionalHardwareInfo = true;
                this.showUserInfo = true;
            },
            (err: any) => console.log(err));
        } else {
            this.showHardwareInfo = false;
            this.showAdditionalHardwareInfo = false;
            this.hardware.assetNumber = '';
            this.hardware.assignedTo = '';
            this.showUserInfo = false;
        }
    }

    onHardwareTypeChange(e: number) {
        this.hardware.hardwareTypeId = e;
    }

    onManufacturerChange(e: number) {
        this.hardware.manufacturerId = e;
    }

    onModelChange(e: number) {
        this.hardware.modelId = e;
    }
    onOperatingSystemChange(e: number) {
        this.hardware.osId = e;
    }

    openAssignModal() {
        const modalRef = this.modalService.open(AssignModalComponent);
        modalRef.componentInstance.inputModel = this.hardware;
    }

    getHardwareDetails(id: number) {
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
        if (this.router.url == '/hardware/add')
        {
            this.dataService.insertHardware(this.hardware)
            .subscribe((hardware: IHardware) => {
                if (hardware) {
                    this.router.navigate(['hardware/' + hardware.id]);
                    this.toastr.success('Device created', 'Success');
                }
                else {
                    this.toastr.error('Error Adding Device', 'Error');
                }
            });
        }
    }

    unassignHardware() {
        event.preventDefault();
        this.dataService.unassignHardware(this.hardware)
            .subscribe((hardware: IHardware) => {
                this.router.navigate(['hardware/' + this.hardware.id]);
                this.toastr.success('Device unassigned', 'Success');
            },
            (err: any) => {
                console.log(err);
                this.toastr.error(err, 'Error');
            });
    }
}
