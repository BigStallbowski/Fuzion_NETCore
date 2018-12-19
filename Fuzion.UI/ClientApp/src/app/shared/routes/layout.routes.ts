import { Routes, RouterModule } from '@angular/router';

export const Full_ROUTES: Routes = [
  {
    path: 'dashboard',
    loadChildren: './dashboard/dashboard.module#DashboardModule'
  },
  {
    path: 'hardware',
    loadChildren: './hardware/hardware.module#HardwareModule'
  },
  {
    path: 'administration',
    loadChildren: './administration/administration.module#AdministrationModule'
  }
];
