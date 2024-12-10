import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BmiAdviceComponent } from './bmi-advice.component';

describe('BMAdviceComponent', () => {
  let component: BmiAdviceComponent;
  let fixture: ComponentFixture<BmiAdviceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BmiAdviceComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(BmiAdviceComponent);
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
