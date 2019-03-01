import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ForeActivitiesServiceProxy, ForeActivityDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@abp/notify/notify.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditForeActivityModalComponent } from './create-or-edit-foreActivity-modal.component';
import { ViewForeActivityModalComponent } from './view-foreActivity-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as moment from 'moment';

@Component({
    templateUrl: './foreActivities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class ForeActivitiesComponent extends AppComponentBase {

    @ViewChild('createOrEditForeActivityModal') createOrEditForeActivityModal: CreateOrEditForeActivityModalComponent;
    @ViewChild('viewForeActivityModalComponent') viewForeActivityModal: ViewForeActivityModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
	
    advancedFiltersAreShown = false;
	filterText = '';
		nameFilter = '';
		binaryObjectTenantIdFilter = '';
		templeNameFilter = '';

	

    constructor(
        injector: Injector,
        private _http: Http,
        private _foreActivitiesServiceProxy: ForeActivitiesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getForeActivities(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._foreActivitiesServiceProxy.getAll(
			this.filterText,
			this.nameFilter,
			this.binaryObjectTenantIdFilter,
			this.templeNameFilter,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createForeActivity(): void {
        this.createOrEditForeActivityModal.show();
    }

    deleteForeActivity(foreActivity: ForeActivityDto): void {
        this.message.confirm(
            '',
            (isConfirmed) => {
                if (isConfirmed) {
                    this._foreActivitiesServiceProxy.delete(foreActivity.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

	exportToExcel(): void {
        this._foreActivitiesServiceProxy.getForeActivitiesToExcel(
		this.filterText,
			this.nameFilter,
			this.binaryObjectTenantIdFilter,
			this.templeNameFilter,
		)
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
}