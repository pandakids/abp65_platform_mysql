import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetForeActivityForView, ForeActivityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewForeActivityModal',
    templateUrl: './view-foreActivity-modal.component.html'
})
export class ViewForeActivityModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetForeActivityForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetForeActivityForView();
        this.item.foreActivity = new ForeActivityDto();
    }

    show(item: GetForeActivityForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
