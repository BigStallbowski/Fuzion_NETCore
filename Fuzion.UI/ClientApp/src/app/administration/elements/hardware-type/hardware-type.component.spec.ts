import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HardwareTypeComponent } from './hardware-type.component';

describe('HardwareTypeComponent', () => {
  let component: HardwareTypeComponent;
  let fixture: ComponentFixture<HardwareTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HardwareTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HardwareTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
