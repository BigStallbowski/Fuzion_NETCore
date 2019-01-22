import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { AssignmentHistoryComponent } from './assignment-history/assignment-history.component';
import { HardwareTypeDropdownComponent } from './hardware-type-dropdown/hardware-type-dropdown.component';
import { ManufacturerDropdownComponent } from './manufacturer-dropdown/manufacturer-dropdown.component';
import { ModelDropdownComponent } from './model-dropdown/model-dropdown.component';
import { NotesComponent } from './notes/notes.component';
import { NotesTimelineComponent } from './notes/notes-timeline/notes-timeline.component';
import { OperatingSystemDropdownComponent } from './operating-system-dropdown/operating-system-dropdown.component';
import { PurposeDropdownComponent } from './purpose-dropdown/purpose-dropdown.component';
import { GenericGridComponent } from './generic-grid/generic-grid.component';

@NgModule({
  exports: [
    NavbarComponent,
    SidebarComponent,
    AssignmentHistoryComponent,
    GenericGridComponent,
    HardwareTypeDropdownComponent,
    ManufacturerDropdownComponent,
    ModelDropdownComponent,
    NotesComponent,
    NotesTimelineComponent,
    OperatingSystemDropdownComponent,
    PurposeDropdownComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    NgbModule,
    NgSelectModule,
    NgxDatatableModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    NavbarComponent,
    SidebarComponent,
    AssignmentHistoryComponent,
    HardwareTypeDropdownComponent,
    ManufacturerDropdownComponent,
    ModelDropdownComponent,
    NotesComponent,
    NotesTimelineComponent,
    OperatingSystemDropdownComponent,
    PurposeDropdownComponent,
    GenericGridComponent
  ]
})

export class SharedModule { }
