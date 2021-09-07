import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemocsrfComponent } from './democsrf.component';

describe('DemocsrfComponent', () => {
  let component: DemocsrfComponent;
  let fixture: ComponentFixture<DemocsrfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DemocsrfComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DemocsrfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
