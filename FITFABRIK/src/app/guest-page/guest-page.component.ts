import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { COOKIE_USER_DATA, routerpath } from 'src/app/constants/deafult';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-guest-page',
  templateUrl: './guest-page.component.html',
  styleUrls: ['./guest-page.component.css'],
})
export class GuestComponent implements OnInit {
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
