import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ForeFatherGiftsServiceProxy, CreateOrEditForeFatherGiftDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ForeFatherLookupTableModalComponent } from './foreFather-lookup-table-modal.component';
import { UserLookupTableModalComponent } from './user-lookup-table-modal.component';


@Component({
    selector: 'createOrEditForeFatherGiftModal',
    templateUrl: './create-or-edit-foreFatherGift-modal.component.html'
})
export class CreateOrEditForeFatherGiftModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('foreFatherLookupTableModal') foreFatherLookupTableModal: ForeFatherLookupTableModalComponent;
	 @ViewChild('userLookupTableModal') userLookupTableModal: UserLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    foreFatherGift: CreateOrEditForeFatherGiftDto = new CreateOrEditForeFatherGiftDto();
	foreFatherName = '';
		 userName = '';
		 

    constructor(
        injector: Injector,
        private _foreFatherGiftsServiceProxy: ForeFatherGiftsServiceProxy
    ) {
        super(injector);
    }

    show(foreFatherGiftId?: number): void {
        if (!foreFatherGiftId) { 
			this.foreFatherGift = new CreateOrEditForeFatherGiftDto();
			this.foreFatherGift.id = foreFatherGiftId;
			this.foreFatherName = '';
		 this.userName = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._foreFatherGiftsServiceProxy.getForeFatherGiftForEdit(foreFatherGiftId).subscribe(result => {
				this.foreFatherGift = result.foreFatherGift;
				this.foreFatherName = result.foreFatherName;
		 this.userName = result.userName;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._foreFatherGiftsServiceProxy.createOrEdit(this.foreFatherGift)
			 .finally(() => { this.saving = false; })
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectForeFatherModal() {
        this.foreFatherLookupTableModal.id = this.foreFatherGift.foreFatherId;
        this.foreFatherLookupTableModal.displayName = this.foreFatherName;
        this.foreFatherLookupTableModal.show();
    }
	    openSelectUserModal() {
        this.userLookupTableModal.id = this.foreFatherGift.userId;
        this.userLookupTableModal.displayName = this.userName;
        this.userLookupTableModal.show();
    }
	

	    setForeFatherIdNull() {
        this.foreFatherGift.foreFatherId = null;
        this.foreFatherName = '';
    }
	    setUserIdNull() {
        this.foreFatherGift.userId = null;
        this.userName = '';
    }
	

	    getNewForeFatherId() {
        this.foreFatherGift.foreFatherId = this.foreFatherLookupTableModal.id;
        this.foreFatherName = this.foreFatherLookupTableModal.displayName;
    }
	    getNewUserId() {
        this.foreFatherGift.userId = this.userLookupTableModal.id;
        this.userName = this.userLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}