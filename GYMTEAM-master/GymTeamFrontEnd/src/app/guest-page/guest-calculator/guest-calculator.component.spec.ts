import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { GuestCalculatorComponent } from 'src/app/guest-page/guest-calculator/guest-calculator.component';

describe('GuestCalculatorComponent', () => {
  let component: GuestCalculatorComponent;
  let fixture: ComponentFixture<GuestCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GuestCalculatorComponent],
      imports: [FormsModule],
    }).compileComponents();

    fixture = TestBed.createComponent(GuestCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate BMI correctly', () => {
    component.weight = 70;
    component.height = 170;
    component.calculateBMI();
    expect(component.bmi).toBeCloseTo(24.22, 2);
  });

  it('should display correct BMI message for normal weight', () => {
    component.weight = 70;
    component.height = 170;
    component.calculateBMI();
    expect(component.bmiMessage).toBe('You have a normal weight.');
  });

  it('should display correct BMI message for underweight', () => {
    component.weight = 50;
    component.height = 170;
    component.calculateBMI();
    expect(component.bmiMessage).toBe('You are underweight.');
  });

  it('should display correct BMI message for overweight', () => {
    component.weight = 90;
    component.height = 170;
    component.calculateBMI();
    expect(component.bmiMessage).toBe('You are overweight.');
  });
});
