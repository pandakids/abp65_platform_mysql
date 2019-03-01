import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ForeActivitiesComponent } from './ancestor/foreActivities/foreActivities.component';
import { UserGiftsComponent } from './ancestor/userGifts/userGifts.component';
import { ForeFatherGiftsComponent } from './ancestor/foreFatherGifts/foreFatherGifts.component';
import { ForeFathersComponent } from './ancestor/foreFathers/foreFathers.component';
import { TempleMembersComponent } from './ancestor/templeMembers/templeMembers.component';
import { TemplesComponent } from './ancestor/temples/temples.component';
import { CitiesComponent } from './ancestor/cities/cities.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'ancestor/foreActivities', component: ForeActivitiesComponent, data: { permission: 'Pages.ForeActivities' }  },
                    { path: 'ancestor/userGifts', component: UserGiftsComponent, data: { permission: 'Pages.UserGifts' }  },
                    { path: 'ancestor/foreFatherGifts', component: ForeFatherGiftsComponent, data: { permission: 'Pages.ForeFatherGifts' }  },
                    { path: 'ancestor/foreFathers', component: ForeFathersComponent, data: { permission: 'Pages.ForeFathers' }  },
                    { path: 'ancestor/templeMembers', component: TempleMembersComponent, data: { permission: 'Pages.TempleMembers' }  },
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
