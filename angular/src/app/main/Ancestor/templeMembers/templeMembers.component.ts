import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { TempleMembersServiceProxy, TempleMemberDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@abp/notify/notify.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditTempleMemberModalComponent } from './create-or-edit-templeMember-modal.component';
import { ViewTempleMemberModalComponent } from './view-templeMember-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as moment from 'moment';

@Component({
    templateUrl: './templeMembers.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class TempleMembersComponent extends AppComponentBase {

    @ViewChild('createOrEditTempleMemberModal') createOrEditTempleMemberModal: CreateOrEditTempleMemberModalComponent;
    @ViewChild('viewTempleMemberModalComponent') viewTempleMemberModal: ViewTempleMemberModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
	
    advancedFiltersAreShown = false;
	filterText = '';
		isApprovedFilter = -1;
		userNameFilter = '';
		templeNameFilter = '';

	

    constructor(
        injector: Injector,
        private _http: Http,
        private _templeMembersServiceProxy: TempleMembersServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getTempleMembers(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._templeMembersServiceProxy.getAll(
			this.filterText,
			this.isApprovedFilter,
			this.userNameFilter,
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

    createTempleMember(): void {
        this.createOrEditTempleMemberModal.show();
    }

    deleteTempleMember(templeMember: TempleMemberDto): void {
        this.message.confirm(
            '',
            (isConfirmed) => {
                if (isConfirmed) {
                    this._templeMembersServiceProxy.delete(templeMember.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

	exportToExcel(): void {
        this._templeMembersServiceProxy.getTempleMembersToExcel(
		this.filterText,
			this.isApprovedFilter,
			this.userNameFilter,
			this.templeNameFilter,
		)
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
}