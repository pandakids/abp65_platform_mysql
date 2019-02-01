import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { TemplesServiceProxy, CreateOrEditTempleDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BinaryObjectLookupTableModalComponent } from './binaryObject-lookup-table-modal.component';
import { UserLookupTableModalComponent } from './user-lookup-table-modal.component';
import { CityLookupTableModalComponent } from './city-lookup-table-modal.component';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'createOrEditTempleModal',
    templateUrl: './create-or-edit-temple-modal.component.html'
})
export class CreateOrEditTempleModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
	 @ViewChild('binaryObjectLookupTableModal') binaryObjectLookupTableModal: BinaryObjectLookupTableModalComponent;
	 @ViewChild('userLookupTableModal') userLookupTableModal: UserLookupTableModalComponent;
	 @ViewChild('cityLookupTableModal') cityLookupTableModal: CityLookupTableModalComponent;
	

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    temple: CreateOrEditTempleDto = new CreateOrEditTempleDto();
	binaryObjectBytes = '';
		 userName = '';
		 citycid = '';
		 

    constructor(
        injector: Injector,
        private _templesServiceProxy: TemplesServiceProxy
    ) {
        super(injector);
    }

    show(templeId?: number): void {
        if (!templeId) { 
			this.temple = new CreateOrEditTempleDto();
			this.temple.id = templeId;
			this.binaryObjectBytes = '';
		 this.userName = '';
		 this.citycid = '';
		 
			this.active = true;
			this.modal.show();
        }
		else{
			this._templesServiceProxy.getTempleForEdit(templeId).subscribe(result => {
				this.temple = result.temple;
				this.binaryObjectBytes = result.binaryObjectBytes;
		 this.userName = result.userName;
		 this.citycid = result.citycid;
		 
				this.active = true;
				this.modal.show();
			});
		}  
    }

    save(): void {
			this.saving = true;
			this._templesServiceProxy.createOrEdit(this.temple)
             .pipe(finalize(() => { this.saving = false; }))
			 .subscribe(() => {
			    this.notify.info(this.l('SavedSuccessfully'));
				this.close();
				this.modalSave.emit(null);
             });
    }

	    openSelectBinaryObjectModal() {
        this.binaryObjectLookupTableModal.id = this.temple.binaryObjectId;
        this.binaryObjectLookupTableModal.displayName = this.binaryObjectBytes;
        this.binaryObjectLookupTableModal.show();
    }
	    openSelectUserModal() {
        this.userLookupTableModal.id = this.temple.userId;
        this.userLookupTableModal.displayName = this.userName;
        this.userLookupTableModal.show();
    }
	    openSelectCityModal() {
        this.cityLookupTableModal.id = this.temple.cityId;
        this.cityLookupTableModal.displayName = this.citycid;
        this.cityLookupTableModal.show();
    }
	

	    setBinaryObjectIdNull() {
        this.temple.binaryObjectId = null;
        this.binaryObjectBytes = '';
    }
	    setUserIdNull() {
        this.temple.userId = null;
        this.userName = '';
    }
	    setCityIdNull() {
        this.temple.cityId = null;
        this.citycid = '';
    }
	

	    getNewBinaryObjectId() {
        this.temple.binaryObjectId = this.binaryObjectLookupTableModal.id;
        this.binaryObjectBytes = this.binaryObjectLookupTableModal.displayName;
    }
	    getNewUserId() {
        this.temple.userId = this.userLookupTableModal.id;
        this.userName = this.userLookupTableModal.displayName;
    }
	    getNewCityId() {
        this.temple.cityId = this.cityLookupTableModal.id;
        this.citycid = this.cityLookupTableModal.displayName;
    }
	

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}