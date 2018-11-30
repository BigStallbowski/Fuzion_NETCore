import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { HardwareRoutingModule } from './hardware-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { SharedModule } from '../shared/shared.module';
import { AssignHardwareComponent } from './assign-hardware/assign-hardware.component';

@NgModule({
    imports: [
        CommonModule,
        HardwareRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        NgbModule,
        NgSelectModule,
        SharedModule
    ],
    declarations: [
        AssignHardwareComponent
    ]
})

export class HardwareModule {
}
