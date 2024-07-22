import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PriceListComponent } from './price-list.component';

describe('PriceListComponent', () => {
  let component: PriceListComponent;
  let fixture: ComponentFixture<PriceListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PriceListComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(PriceListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render BMI advice sections', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.bmi-advice-section')).toBeTruthy();
    expect(compiled.querySelectorAll('.bmi-category').length).toBe(4);
  });
});
