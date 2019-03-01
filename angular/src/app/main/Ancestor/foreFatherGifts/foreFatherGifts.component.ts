import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ForeFatherGiftsServiceProxy, ForeFatherGiftDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@abp/notify/notify.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditForeFatherGiftModalComponent } from './create-or-edit-foreFatherGift-modal.component';
import { ViewForeFatherGiftModalComponent } from './view-foreFatherGift-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as moment from 'moment';

@Component({
    templateUrl: './foreFatherGifts.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class ForeFatherGiftsComponent extends AppComponentBase {

    @ViewChild('createOrEditForeFatherGiftModal') createOrEditForeFatherGiftModal: CreateOrEditForeFatherGiftModalComponent;
    @ViewChild('viewForeFatherGiftModalComponent') viewForeFatherGiftModal: ViewForeFatherGiftModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
	
    advancedFiltersAreShown = false;
	filterText = '';
		foreFatherNameFilter = '';
		userNameFilter = '';

	

    constructor(
        injector: Injector,
        private _http: Http,
        private _foreFatherGiftsServiceProxy: ForeFatherGiftsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getForeFatherGifts(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._foreFatherGiftsServiceProxy.getAll(
			this.filterText,
			this.foreFatherNameFilter,
			this.userNameFilter,
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

    createForeFatherGift(): void {
        this.createOrEditForeFatherGiftModal.show();
    }

    deleteForeFatherGift(foreFatherGift: ForeFatherGiftDto): void {
        this.message.confirm(
            '',
            (isConfirmed) => {
                if (isConfirmed) {
                    this._foreFatherGiftsServiceProxy.delete(foreFatherGift.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

	
}