import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HardwareComponent } from './hardware.component';

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: HardwareComponent,
                data: {
                    title: 'Assign Hardware'
                }
            },
            {
                path: ':id',
                component: HardwareComponent
            },
            {
                path: '/add',
                component: HardwareComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class HardwareRoutingModule { }