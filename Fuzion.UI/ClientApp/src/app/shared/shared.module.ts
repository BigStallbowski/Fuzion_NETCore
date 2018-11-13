import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NavbarComponent } from "./navbar/navbar.component";
import { SidebarComponent } from "./sidebar/sidebar.component";



@NgModule({
  exports: [
    NavbarComponent,
    SidebarComponent,
  ],
  imports: [
    RouterModule,
    CommonModule,
    NgbModule
  ],
  declarations: [
    NavbarComponent,
    SidebarComponent,
  ]
})
export class SharedModule { }
