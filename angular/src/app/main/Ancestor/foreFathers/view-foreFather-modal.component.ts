import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetForeFatherForView, ForeFatherDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewForeFatherModal',
    templateUrl: './view-foreFather-modal.component.html'
})
export class ViewForeFatherModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetForeFatherForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetForeFatherForView();
        this.item.foreFather = new ForeFatherDto();
    }

    show(item: GetForeFatherForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
