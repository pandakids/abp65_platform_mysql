import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { ForeActivitiesComponent } from './ancestor/foreActivities/foreActivities.component';
import { ViewForeActivityModalComponent } from './ancestor/foreActivities/view-foreActivity-modal.component';
import { CreateOrEditForeActivityModalComponent } from './ancestor/foreActivities/create-or-edit-foreActivity-modal.component';

import { UserGiftsComponent } from './ancestor/userGifts/userGifts.component';
import { ViewUserGiftModalComponent } from './ancestor/userGifts/view-userGift-modal.component';
import { CreateOrEditUserGiftModalComponent } from './ancestor/userGifts/create-or-edit-userGift-modal.component';

import { ForeFatherGiftsComponent } from './ancestor/foreFatherGifts/foreFatherGifts.component';
import { ViewForeFatherGiftModalComponent } from './ancestor/foreFatherGifts/view-foreFatherGift-modal.component';
import { CreateOrEditForeFatherGiftModalComponent } from './ancestor/foreFatherGifts/create-or-edit-foreFatherGift-modal.component';
import { ForeFatherLookupTableModalComponent } from './ancestor/foreFatherGifts/foreFather-lookup-table-modal.component';

import { ForeFathersComponent } from './ancestor/foreFathers/foreFathers.component';
import { ViewForeFatherModalComponent } from './ancestor/foreFathers/view-foreFather-modal.component';
import { CreateOrEditForeFatherModalComponent } from './ancestor/foreFathers/create-or-edit-foreFather-modal.component';

import { TempleMembersComponent } from './ancestor/templeMembers/templeMembers.component';
import { ViewTempleMemberModalComponent } from './ancestor/templeMembers/view-templeMember-modal.component';
import { CreateOrEditTempleMemberModalComponent } from './ancestor/templeMembers/create-or-edit-templeMember-modal.component';
import { TempleLookupTableModalComponent } from './ancestor/templeMembers/temple-lookup-table-modal.component';

import { TemplesComponent } from './ancestor/temples/temples.component';
import { ViewTempleModalComponent } from './ancestor/temples/view-temple-modal.component';
import { CreateOrEditTempleModalComponent } from './ancestor/temples/create-or-edit-temple-modal.component';
import { BinaryObjectLookupTableModalComponent } from './ancestor/temples/binaryObject-lookup-table-modal.component';
import { UserLookupTableModalComponent } from './ancestor/temples/user-lookup-table-modal.component';
import { CityLookupTableModalComponent } from './ancestor/temples/city-lookup-table-modal.component';

import { CitiesComponent } from './ancestor/cities/cities.component';
import { ViewCityModalComponent } from './ancestor/cities/view-city-modal.component';
import { CreateOrEditCityModalComponent } from './ancestor/cities/create-or-edit-city-modal.component';

import { AutoCompleteModule } from 'primeng/primeng';
import { PaginatorModule } from 'primeng/primeng';
import { EditorModule } from 'primeng/primeng';
import { InputMaskModule } from 'primeng/primeng';import { FileUploadModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';

import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule, TabsModule, TooltipModule, BsDropdownModule } from 'ngx-bootstrap';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MainRoutingModule } from './main-routing.module';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { BsDatepickerModule, BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';

NgxBootstrapDatePickerConfigService.registerNgxBootstrapDatePickerLocales();

@NgModule({
    imports: [
		FileUploadModule,
		AutoCompleteModule,
		PaginatorModule,
		EditorModule,
		InputMaskModule,		TableModule,

        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        NgxChartsModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot()
    ],
    declarations: [
		ForeActivitiesComponent,
		ViewForeActivityModalComponent,		CreateOrEditForeActivityModalComponent,
		UserGiftsComponent,
		ViewUserGiftModalComponent,		CreateOrEditUserGiftModalComponent,
		ForeFatherGiftsComponent,
		ViewForeFatherGiftModalComponent,		CreateOrEditForeFatherGiftModalComponent,
    ForeFatherLookupTableModalComponent,
		ForeFathersComponent,
		ViewForeFatherModalComponent,		CreateOrEditForeFatherModalComponent,
		TempleMembersComponent,
		ViewTempleMemberModalComponent,		CreateOrEditTempleMemberModalComponent,
    TempleLookupTableModalComponent,
		TemplesComponent,
		ViewTempleModalComponent,		CreateOrEditTempleModalComponent,
    BinaryObjectLookupTableModalComponent,
    UserLookupTableModalComponent,
    CityLookupTableModalComponent,
		CitiesComponent,
		ViewCityModalComponent,		CreateOrEditCityModalComponent,
        DashboardComponent
    ],
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale }
    ]
})
export class MainModule { }
