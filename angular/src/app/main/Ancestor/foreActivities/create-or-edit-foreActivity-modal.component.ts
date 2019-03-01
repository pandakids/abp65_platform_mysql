import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ForeActivitiesServiceProxy, CreateOrEditForeActivityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BinaryObjectLookupTableModalComponent } from './binaryObject-lookup-table-modal.component';
import { TempleLookupTableModalComponent } from './temple-lookup-table-modal.component';


@Component({
    selector: 'createOrEditForeActivityModal',
    templateUrl: './create-or-edit-foreActivity-modal.component.html'
})
export class CreateOrEditForeActivityModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('binaryObjectLookupTableModal') binaryObjectLookupTableModal: BinaryObjectLookupTableModalComponent;
	 @ViewChild('templeLookupTableModal') templeLookupTableModal: TempleLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    foreActivity: CreateOrEditForeActivityDto = new CreateOrEditForeActivityDto();
	binaryObjectTenantId = '';
		 templeName = '';
		 

    constructor(
        injector: Injector,
        private _foreActivitiesServiceProxy: ForeActivitiesServiceProxy
    ) {
        super(injector);
    }

    show(foreActivityId?: number): void {
        if (!foreActivityId) { 
			this.foreActivity = new CreateOrEditForeActivityDto();
			this.foreActivity.id = foreActivityId;
			this.binaryObjectTenantId = '';
		 this.templeName = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._foreActivitiesServiceProxy.getForeActivityForEdit(foreActivityId).subscribe(result => {
				this.foreActivity = result.foreActivity;
				this.binaryObjectTenantId = result.binaryObjectTenantId;
		 this.templeName = result.templeName;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._foreActivitiesServiceProxy.createOrEdit(this.foreActivity)
			 .finally(() => { this.saving = false; })
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectBinaryObjectModal() {
        this.binaryObjectLookupTableModal.id = this.foreActivity.binaryObjectId;
        this.binaryObjectLookupTableModal.displayName = this.binaryObjectTenantId;
        this.binaryObjectLookupTableModal.show();
    }
	    openSelectTempleModal() {
        this.templeLookupTableModal.id = this.foreActivity.templeId;
        this.templeLookupTableModal.displayName = this.templeName;
        this.templeLookupTableModal.show();
    }
	

	    setBinaryObjectIdNull() {
        this.foreActivity.binaryObjectId = null;
        this.binaryObjectTenantId = '';
    }
	    setTempleIdNull() {
        this.foreActivity.templeId = null;
        this.templeName = '';
    }
	

	    getNewBinaryObjectId() {
        this.foreActivity.binaryObjectId = this.binaryObjectLookupTableModal.id;
        this.binaryObjectTenantId = this.binaryObjectLookupTableModal.displayName;
    }
	    getNewTempleId() {
        this.foreActivity.templeId = this.templeLookupTableModal.id;
        this.templeName = this.templeLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}