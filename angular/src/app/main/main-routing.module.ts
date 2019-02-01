import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TemplesComponent } from './ancestor/temples/temples.component';
import { CitiesComponent } from './ancestor/cities/cities.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'ancestor/temples', component: TemplesComponent, data: { permission: 'Pages.Temples' }  },
                    { path: 'ancestor/cities', component: CitiesComponent, data: { permission: 'Pages.Cities' }  },
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
