import { Component, OnInit, ElementRef } from '@angular/core';

var fireRefreshEventOnWindow = function () {
  var evt = document.createEvent("HTMLEvents");
  evt.initEvent('resize', true, false);
  window.dispatchEvent(evt);
};

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: []
})

export class LayoutComponent implements OnInit {
  constructor(private elementRef: ElementRef) { }

  ngOnInit() {
    this.elementRef.nativeElement.querySelector('#sidebarToggle')
      .addEventListener('click', this.onClick.bind(this));
  }

  onClick(event) {
    setTimeout(() => { fireRefreshEventOnWindow() }, 300);
  }
}
