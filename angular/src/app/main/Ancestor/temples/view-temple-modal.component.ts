import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetTempleForView, TempleDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewTempleModal',
    templateUrl: './view-temple-modal.component.html'
})
export class ViewTempleModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetTempleForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetTempleForView();
        this.item.temple = new TempleDto();
    }

    show(item: GetTempleForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
