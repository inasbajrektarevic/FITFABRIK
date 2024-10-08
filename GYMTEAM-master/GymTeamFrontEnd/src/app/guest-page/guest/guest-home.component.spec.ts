import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuestHomeComponent } from 'src/app/guest-page/guest/guest-home.component';

describe('GuestHomeComponent', () => {
  let component: GuestHomeComponent;
  let fixture: ComponentFixture<GuestHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GuestHomeComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(GuestHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
