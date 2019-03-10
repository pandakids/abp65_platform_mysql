import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ForeFathersServiceProxy, ForeFatherDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@abp/notify/notify.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditForeFatherModalComponent } from './create-or-edit-foreFather-modal.component';
import { ViewForeFatherModalComponent } from './view-foreFather-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as moment from 'moment';

@Component({
    templateUrl: './foreFathers.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class ForeFathersComponent extends AppComponentBase {

    @ViewChild('createOrEditForeFatherModal') createOrEditForeFatherModal: CreateOrEditForeFatherModalComponent;
    @ViewChild('viewForeFatherModalComponent') viewForeFatherModal: ViewForeFatherModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
	
    advancedFiltersAreShown = false;
	filterText = '';
		nameFilter = '';
		centuryFilter = '';
		binaryObjectTenantIdFilter = '';
		templeNameFilter = '';

	

    constructor(
        injector: Injector,
        private _http: Http,
        private _foreFathersServiceProxy: ForeFathersServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getForeFathers(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._foreFathersServiceProxy.getAll(
			this.filterText,
			this.nameFilter,
			this.centuryFilter,
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

    createForeFather(): void {
        this.createOrEditForeFatherModal.show();
    }

    deleteForeFather(foreFather: ForeFatherDto): void {
        this.message.confirm(
            '',
            (isConfirmed) => {
                if (isConfirmed) {
                    this._foreFathersServiceProxy.delete(foreFather.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

	exportToExcel(): void {
        this._foreFathersServiceProxy.getForeFathersToExcel(
		this.filterText,
			this.nameFilter,
			this.centuryFilter,
			this.binaryObjectTenantIdFilter,
			this.templeNameFilter,
		)
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
}