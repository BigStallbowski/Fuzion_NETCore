import { Component , OnInit } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { Router, ActivatedRoute } from '@angular/router';

import { DataService } from '../../core/data.service';
import { IHardware, IList } from '../../shared/interfaces/interfaces';

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
    hardwareTypeList: IList[];
    manufacturerList: IList[];
    modelList: IList[];
    operatingSystemList: IList[];
    purposeList: IList[];

    showHardwareInfo: boolean;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    ngOnInit() {
        this.getHardwareList();
        this.getHardwareTypeList();
        this.getManufacturerList();
        this.getModelList();
        this.getOperatingSystemList();
        this.getPurposeList();
        this.showHardwareInfo = false;
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

    onHardwareClear() {
        console.log("Cleared");
    }

    getHardwareList() {
        this.dataService.getHardwareList().subscribe((hw: IHardware[]) => 
            this.hardwareList = hw.filter(unassigned => unassigned.isAssigned == 0));
    }

    getHardwareTypeList() {
        this.dataService.getHardwareTypeList().subscribe((hardwareTypes: IList[]) => this.hardwareTypeList = hardwareTypes);
    }

    getManufacturerList() {
        this.dataService.getManufacturerList().subscribe((manufacturers: IList[]) => this.manufacturerList = manufacturers);
    }

    getModelList() {
        this.dataService.getModelList().subscribe((models: IList[]) => this.modelList = models);
    }

    getOperatingSystemList() {
        this.dataService.getOperatingSystemList().subscribe((operatingSystems: IList[]) => this.operatingSystemList = operatingSystems);
    }

    getPurposeList() {
        this.dataService.getPurposeList().subscribe((purposes: IList[]) => this.purposeList = purposes);
    }

    submit() {
            this.dataService.assignHardware(this.hardware)
                .subscribe((hardware: IHardware) => {
                },
                (err: any) => console.log(err));
        
    }
}