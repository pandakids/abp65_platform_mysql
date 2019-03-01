import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { UserGiftsServiceProxy, CreateOrEditUserGiftDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UserLookupTableModalComponent } from './user-lookup-table-modal.component';


@Component({
    selector: 'createOrEditUserGiftModal',
    templateUrl: './create-or-edit-userGift-modal.component.html'
})
export class CreateOrEditUserGiftModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('userLookupTableModal') userLookupTableModal: UserLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    userGift: CreateOrEditUserGiftDto = new CreateOrEditUserGiftDto();
	userName = '';
		 

    constructor(
        injector: Injector,
        private _userGiftsServiceProxy: UserGiftsServiceProxy
    ) {
        super(injector);
    }

    show(userGiftId?: number): void {
        if (!userGiftId) { 
			this.userGift = new CreateOrEditUserGiftDto();
			this.userGift.id = userGiftId;
			this.userName = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._userGiftsServiceProxy.getUserGiftForEdit(userGiftId).subscribe(result => {
				this.userGift = result.userGift;
				this.userName = result.userName;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._userGiftsServiceProxy.createOrEdit(this.userGift)
			 .finally(() => { this.saving = false; })
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectUserModal() {
        this.userLookupTableModal.id = this.userGift.userId;
        this.userLookupTableModal.displayName = this.userName;
        this.userLookupTableModal.show();
    }
	

	    setUserIdNull() {
        this.userGift.userId = null;
        this.userName = '';
    }
	

	    getNewUserId() {
        this.userGift.userId = this.userLookupTableModal.id;
        this.userName = this.userLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}