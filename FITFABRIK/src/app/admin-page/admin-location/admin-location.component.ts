import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-location',
  templateUrl: './admin-location.component.html',
  styleUrls: ['./admin-location.component.css'],
})
export class AdminLocationComponent {
  weight: number = 0;
  height: number = 0;
  gender: string = 'Male'; // Default to Male
  bmi: number = 0;
  bmiMessage: string = '';

  calculateBMI(): void {
    if (this.weight && this.height) {
      const heightInMeters = this.height / 100;
      this.bmi = this.weight / (heightInMeters * heightInMeters);

      if (this.bmi < 18.5) {
        this.bmiMessage = `You are underweight. (${this.gender})`;
      } else if (this.bmi >= 18.5 && this.bmi < 24.9) {
        this.bmiMessage = `You have a normal weight. (${this.gender})`;
      } else if (this.bmi >= 25 && this.bmi < 29.9) {
        this.bmiMessage = `You are overweight. (${this.gender})`;
      } else {
        this.bmiMessage = `You are obese. (${this.gender})`;
      }
    }
  }
}
