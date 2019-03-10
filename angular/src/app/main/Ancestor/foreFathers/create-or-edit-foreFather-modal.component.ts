import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ForeFathersServiceProxy, CreateOrEditForeFatherDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BinaryObjectLookupTableModalComponent } from './binaryObject-lookup-table-modal.component';
import { TempleLookupTableModalComponent } from './temple-lookup-table-modal.component';


@Component({
    selector: 'createOrEditForeFatherModal',
    templateUrl: './create-or-edit-foreFather-modal.component.html'
})
export class CreateOrEditForeFatherModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('binaryObjectLookupTableModal') binaryObjectLookupTableModal: BinaryObjectLookupTableModalComponent;
	 @ViewChild('templeLookupTableModal') templeLookupTableModal: TempleLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    foreFather: CreateOrEditForeFatherDto = new CreateOrEditForeFatherDto();
	binaryObjectTenantId = '';
		 templeName = '';
		 

    constructor(
        injector: Injector,
        private _foreFathersServiceProxy: ForeFathersServiceProxy
    ) {
        super(injector);
    }

    show(foreFatherId?: number): void {
        if (!foreFatherId) { 
			this.foreFather = new CreateOrEditForeFatherDto();
			this.foreFather.id = foreFatherId;
			this.binaryObjectTenantId = '';
		 this.templeName = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._foreFathersServiceProxy.getForeFatherForEdit(foreFatherId).subscribe(result => {
				this.foreFather = result.foreFather;
				this.binaryObjectTenantId = result.binaryObjectTenantId;
		 this.templeName = result.templeName;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._foreFathersServiceProxy.createOrEdit(this.foreFather)
			 .finally(() => { this.saving = false; })
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectBinaryObjectModal() {
        this.binaryObjectLookupTableModal.id = this.foreFather.binaryObjectId;
        this.binaryObjectLookupTableModal.displayName = this.binaryObjectTenantId;
        this.binaryObjectLookupTableModal.show();
    }
	    openSelectTempleModal() {
        this.templeLookupTableModal.id = this.foreFather.templeId;
        this.templeLookupTableModal.displayName = this.templeName;
        this.templeLookupTableModal.show();
    }
	

	    setBinaryObjectIdNull() {
        this.foreFather.binaryObjectId = null;
        this.binaryObjectTenantId = '';
    }
	    setTempleIdNull() {
        this.foreFather.templeId = null;
        this.templeName = '';
    }
	

	    getNewBinaryObjectId() {
        this.foreFather.binaryObjectId = this.binaryObjectLookupTableModal.id;
        this.binaryObjectTenantId = this.binaryObjectLookupTableModal.displayName;
    }
	    getNewTempleId() {
        this.foreFather.templeId = this.templeLookupTableModal.id;
        this.templeName = this.templeLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}