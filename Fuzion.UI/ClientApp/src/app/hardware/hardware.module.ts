import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { HardwareRoutingModule } from './hardware-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { SharedModule } from '../shared/shared.module';
import { AssignModalComponent } from './assign-modal/assign-modal.component';
import { HardwareComponent } from './hardware.component';

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
        HardwareComponent,
        AssignModalComponent
    ], 
    entryComponents: [
        AssignModalComponent
    ]
})

export class HardwareModule {
}
