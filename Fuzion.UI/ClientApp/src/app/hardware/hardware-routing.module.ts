import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AssignHardwareComponent } from './assign-hardware/assign-hardware.component';

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'assign',
                component: AssignHardwareComponent,
                data: {
                    title: 'Assign Hardware'
                }
            },
            {
                path: 'assign/:id',
                component: AssignHardwareComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class HardwareRoutingModule { }