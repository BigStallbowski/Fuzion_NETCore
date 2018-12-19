import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HardwareTypeComponent } from './elements/hardware-type/hardware-type.component';
import { ManufacturerComponent } from './elements/manufacturer/manufacturer.component';
import { ModelComponent } from './elements/model/model.component';
import { OperatingsystemComponent } from './elements/operatingsystem/operatingsystem.component';
import { PurposeComponent } from './elements/purpose/purpose.component';
import { SettingsComponent } from './elements/settings/settings.component';

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'hardwaretypes',
                component: HardwareTypeComponent,
            },
            {
                path: 'manufacturers',
                component: ManufacturerComponent
            },
            {
                path: 'models',
                component: ModelComponent
            },
            {
                path: 'operatingsystems',
                component: OperatingsystemComponent
            },
            {
                path: 'purposes',
                component: PurposeComponent
            },
            {
                path: 'settings',
                component: SettingsComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdministrationRoutingModule { }