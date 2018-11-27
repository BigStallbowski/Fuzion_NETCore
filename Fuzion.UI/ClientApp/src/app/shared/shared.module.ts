import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select'; 

import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HardwareTypeDropdownComponent } from './hardware-type-dropdown/hardware-type-dropdown.component';
import { ManufacturerDropdownComponent } from './manufacturer-dropdown/manufacturer-dropdown.component';
import { ModelDropdownComponent } from './model-dropdown/model-dropdown.component';
import { OperatingSystemDropdownComponent } from './operating-system-dropdown/operating-system-dropdown.component';
import { PurposeDropdownComponent } from './purpose-dropdown/purpose-dropdown.component';

@NgModule({
  exports: [
    NavbarComponent,
    SidebarComponent,
    HardwareTypeDropdownComponent,
    ManufacturerDropdownComponent,
    ModelDropdownComponent,
    OperatingSystemDropdownComponent,
    PurposeDropdownComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    NgbModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    NavbarComponent,
    SidebarComponent,
    HardwareTypeDropdownComponent,
    ManufacturerDropdownComponent,
    ModelDropdownComponent,
    OperatingSystemDropdownComponent,
    PurposeDropdownComponent
  ]
})

export class SharedModule { }
