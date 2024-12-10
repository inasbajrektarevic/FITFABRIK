import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-guest-advice',
  templateUrl: './guest-advice.component.html',
  styleUrls: ['./guest-advice.component.css'],
})
export class GuestAdviceComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {
    // No API calls or dynamic data needed, just display static advice
  }
}
