import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { TemplesServiceProxy, TempleDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@abp/notify/notify.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditTempleModalComponent } from './create-or-edit-temple-modal.component';
import { ViewTempleModalComponent } from './view-temple-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as moment from 'moment';

@Component({
    templateUrl: './temples.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class TemplesComponent extends AppComponentBase {

    @ViewChild('createOrEditTempleModal') createOrEditTempleModal: CreateOrEditTempleModalComponent;
    @ViewChild('viewTempleModalComponent') viewTempleModal: ViewTempleModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
	
    advancedFiltersAreShown = false;
	filterText = '';
		nameFilter = '';
		fanmilyNameFilter = '';
		isShowFilter = -1;
		binaryObjectBytesFilter = '';
		userNameFilter = '';
		citycidFilter = '';

	

    constructor(
        injector: Injector,
        private _http: Http,
        private _templesServiceProxy: TemplesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getTemples(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._templesServiceProxy.getAll(
			this.filterText,
			this.nameFilter,
			this.fanmilyNameFilter,
			this.isShowFilter,
			this.binaryObjectBytesFilter,
			this.userNameFilter,
			this.citycidFilter,
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

    createTemple(): void {
        this.createOrEditTempleModal.show();
    }

    deleteTemple(temple: TempleDto): void {
        this.message.confirm(
            '',
            (isConfirmed) => {
                if (isConfirmed) {
                    this._templesServiceProxy.delete(temple.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

	exportToExcel(): void {
        this._templesServiceProxy.getTemplesToExcel(
		this.filterText,
			this.nameFilter,
			this.fanmilyNameFilter,
			this.isShowFilter,
			this.binaryObjectBytesFilter,
			this.userNameFilter,
			this.citycidFilter,
		)
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
}