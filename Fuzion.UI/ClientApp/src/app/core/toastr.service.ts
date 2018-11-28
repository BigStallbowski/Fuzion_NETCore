import { Injectable } from '@angular/core';
import { SnotifyService, SnotifyPosition, SnotifyToastConfig } from 'ng-snotify';

@Injectable({
    providedIn: 'root'
})

export class ToastrService {
    style = 'material';
    title = '';
    body = '';
    timeout = 3000;
    position: SnotifyPosition = SnotifyPosition.rightBottom;
    progressBar = true;
    closeClick = true;
    newTop = true;
    backdrop = -1;
    dockMax = 8;
    blockMax = 6;
    pauseHover = true;
    titleMaxLength = 15;
    bodyMaxLength = 80;

    constructor(private snotifyService: SnotifyService) {}

    getConfig(): SnotifyToastConfig {
        this.snotifyService.setDefaults({
            global: {
                newOnTop: this.newTop,
                maxAtPosition: this.blockMax,
                maxOnScreen: this.dockMax,
            }
        });
        return {
            bodyMaxLength: this.bodyMaxLength,
            titleMaxLength: this.titleMaxLength,
            backdrop: this.backdrop,
            position: this.position,
            timeout: this.timeout,
            showProgressBar: this.progressBar,
            closeOnClick: this.closeClick,
            pauseOnHover: this.pauseHover
        };
    }

    error(body: string, title: string) {
        this.snotifyService.warning(this.body = body, this.title = title, this.getConfig());
    }

    success(body: string, title: string) {
        this.snotifyService.success(this.body = body, this.title = title, this.getConfig());
    }

    warning(body: string, title: string) {
        this.snotifyService.warning(this.body = body, this.title = title, this.getConfig());
    }
}
