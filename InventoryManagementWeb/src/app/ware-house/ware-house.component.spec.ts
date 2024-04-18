import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WareHouseComponent } from './ware-house.component';

describe('WareHouseComponent', () => {
  let component: WareHouseComponent;
  let fixture: ComponentFixture<WareHouseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WareHouseComponent]
    });
    fixture = TestBed.createComponent(WareHouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
