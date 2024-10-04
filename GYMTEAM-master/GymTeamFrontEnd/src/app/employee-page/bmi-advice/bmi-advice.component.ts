import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bmi-advice',
  templateUrl: './bmi-advice.component.html',
  styleUrls: ['./bmi-advice.component.css'],
})
export class BmiAdviceComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {
    // No API calls or dynamic data needed, just display static advice
  }
}
