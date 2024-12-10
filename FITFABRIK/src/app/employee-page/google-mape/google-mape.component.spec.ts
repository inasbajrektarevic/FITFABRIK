import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoogleMapeComponent } from './google-mape.component';

describe('GoogleMapeComponent', () => {
  let component: GoogleMapeComponent;
  let fixture: ComponentFixture<GoogleMapeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoogleMapeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoogleMapeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
