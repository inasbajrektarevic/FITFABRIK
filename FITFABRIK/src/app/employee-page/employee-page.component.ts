import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, routerpath } from 'src/app/constants/deafult';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee-page',
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.css'],
})
export class EmployeePageComponent implements OnInit {
  korisnik: any;

  constructor(private cookie: CookieService, private httpClient: HttpClient) {}

  ngOnInit(): void {
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);
    if (cookieValue) {
      let userId = JSON.parse(cookieValue);
      this.httpClient
        .get(`${routerpath}/api/Korisnik/GetById?id=${userId}`)
        .subscribe((res) => {
          if (!!res) {
            this.korisnik = res;
          }
        });
    }
  }
}
