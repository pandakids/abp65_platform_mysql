import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetTempleMemberForView, TempleMemberDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewTempleMemberModal',
    templateUrl: './view-templeMember-modal.component.html'
})
export class ViewTempleMemberModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item : GetTempleMemberForView;
	

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetTempleMemberForView();
        this.item.templeMember = new TempleMemberDto();
    }

    show(item: GetTempleMemberForView): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
