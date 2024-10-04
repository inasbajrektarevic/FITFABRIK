import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { AdminLocationComponent } from './admin-location.component';

describe('AdminLocationComponent', () => {
  let component: AdminLocationComponent;
  let fixture: ComponentFixture<AdminLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminLocationComponent],
      imports: [FormsModule],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminLocationComponent);
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
});
