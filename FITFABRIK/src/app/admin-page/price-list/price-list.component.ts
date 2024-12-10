import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.css'],
})
export class PriceListComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {
    // No API calls or dynamic data needed, just display static advice
  }
}
