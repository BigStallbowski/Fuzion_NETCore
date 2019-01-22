import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { AdministrationRoutingModule } from './administration-routing.module';

import { HardwareTypeComponent } from './elements/hardware-type/hardware-type.component';
import { ManufacturerComponent } from './elements/manufacturer/manufacturer.component';
import { ModelComponent } from './elements/model/model.component';
import { OperatingsystemComponent } from './elements/operatingsystem/operatingsystem.component';
import { PurposeComponent } from './elements/purpose/purpose.component';
import { SettingsComponent } from './elements/settings/settings.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    AdministrationRoutingModule,
    CommonModule,
    FormsModule,
    NgbModule,
    NgxDatatableModule,
    ReactiveFormsModule,
    SharedModule
  ],
  declarations: [
    HardwareTypeComponent,
    ManufacturerComponent,
    ModelComponent,
    OperatingsystemComponent,
    PurposeComponent,
    SettingsComponent
  ]
})
export class AdministrationModule { }
