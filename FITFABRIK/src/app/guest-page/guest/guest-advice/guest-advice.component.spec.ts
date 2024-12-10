import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GuestAdviceComponent } from './guest-advice.component';

describe('GuestAdviceComponent', () => {
  let component: GuestAdviceComponent;
  let fixture: ComponentFixture<GuestAdviceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GuestAdviceComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(GuestAdviceComponent);
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
