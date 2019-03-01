import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetForeFatherGiftForView, ForeFatherGiftDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewForeFatherGiftModal',
    templateUrl: './view-foreFatherGift-modal.component.html'
})
export class ViewForeFatherGiftModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetForeFatherGiftForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetForeFatherGiftForView();
        this.item.foreFatherGift = new ForeFatherGiftDto();
    }

    show(item: GetForeFatherGiftForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
