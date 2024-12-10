import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoogleMapareComponent } from './google-mapare.component';

describe('GoogleMapareComponent', () => {
  let component: GoogleMapareComponent;
  let fixture: ComponentFixture<GoogleMapareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoogleMapareComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoogleMapareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
