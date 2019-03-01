import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetUserGiftForView, UserGiftDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewUserGiftModal',
    templateUrl: './view-userGift-modal.component.html'
})
export class ViewUserGiftModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetUserGiftForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetUserGiftForView();
        this.item.userGift = new UserGiftDto();
    }

    show(item: GetUserGiftForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
