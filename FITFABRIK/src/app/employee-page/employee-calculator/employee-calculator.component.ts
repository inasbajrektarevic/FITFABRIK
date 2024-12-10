import { Component } from '@angular/core';

@Component({
  selector: 'app-employee-calculator',
  templateUrl: './employee-calculator.component.html',
  styleUrls: ['./employee-calculator.component.css']
})
export class EmployeeCalculatorComponent {
  weight: number = 0;
  height: number = 0;
  gender: string = 'Male'; // Default to Male
  bmi: number = 0;
  bmiMessage: string = '';

  calculateBMI(): void {
    if (this.weight && this.height) {
      const heightInMeters = this.height / 100;
      this.bmi = this.weight / (heightInMeters * heightInMeters);
      this.setBmiMessage();
    }
  }

  private setBmiMessage(): void {
    if (this.bmi < 18.5) {
      this.bmiMessage = 'You are underweight.';
    } else if (this.bmi >= 18.5 && this.bmi < 24.9) {
      this.bmiMessage = 'You have a normal weight.';
    } else {
      this.bmiMessage = 'You are overweight.';
    }
  }
}
