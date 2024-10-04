import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { EmployeeCalculatorComponent } from './employee-calculator.component';

describe('EmployeeCalculatorComponent', () => {
  let component: EmployeeCalculatorComponent;
  let fixture: ComponentFixture<EmployeeCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeCalculatorComponent],
      imports: [FormsModule],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeeCalculatorComponent);
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
