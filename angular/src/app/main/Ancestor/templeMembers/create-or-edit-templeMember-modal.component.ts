import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { TempleMembersServiceProxy, CreateOrEditTempleMemberDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UserLookupTableModalComponent } from './user-lookup-table-modal.component';
import { TempleLookupTableModalComponent } from './temple-lookup-table-modal.component';


@Component({
    selector: 'createOrEditTempleMemberModal',
    templateUrl: './create-or-edit-templeMember-modal.component.html'
})
export class CreateOrEditTempleMemberModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('userLookupTableModal') userLookupTableModal: UserLookupTableModalComponent;
	 @ViewChild('templeLookupTableModal') templeLookupTableModal: TempleLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    templeMember: CreateOrEditTempleMemberDto = new CreateOrEditTempleMemberDto();
	userName = '';
		 templeName = '';
		 

    constructor(
        injector: Injector,
        private _templeMembersServiceProxy: TempleMembersServiceProxy
    ) {
        super(injector);
    }

    show(templeMemberId?: number): void {
        if (!templeMemberId) { 
			this.templeMember = new CreateOrEditTempleMemberDto();
			this.templeMember.id = templeMemberId;
			this.userName = '';
		 this.templeName = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._templeMembersServiceProxy.getTempleMemberForEdit(templeMemberId).subscribe(result => {
				this.templeMember = result.templeMember;
				this.userName = result.userName;
		 this.templeName = result.templeName;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._templeMembersServiceProxy.createOrEdit(this.templeMember)
			 .finally(() => { this.saving = false; })
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectUserModal() {
        this.userLookupTableModal.id = this.templeMember.userId;
        this.userLookupTableModal.displayName = this.userName;
        this.userLookupTableModal.show();
    }
	    openSelectTempleModal() {
        this.templeLookupTableModal.id = this.templeMember.templeId;
        this.templeLookupTableModal.displayName = this.templeName;
        this.templeLookupTableModal.show();
    }
	

	    setUserIdNull() {
        this.templeMember.userId = null;
        this.userName = '';
    }
	    setTempleIdNull() {
        this.templeMember.templeId = null;
        this.templeName = '';
    }
	

	    getNewUserId() {
        this.templeMember.userId = this.userLookupTableModal.id;
        this.userName = this.userLookupTableModal.displayName;
    }
	    getNewTempleId() {
        this.templeMember.templeId = this.templeLookupTableModal.id;
        this.templeName = this.templeLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}