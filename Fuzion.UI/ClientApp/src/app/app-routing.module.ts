import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';

import { LayoutComponent } from "./layout/layout.component";

import { Full_ROUTES } from "./shared/routes/layout.routes";

const appRoutes: Routes = [
  { path: '', component: LayoutComponent, data: { title: 'full Views' }, children: Full_ROUTES},
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})

export class AppRoutingModule {
}