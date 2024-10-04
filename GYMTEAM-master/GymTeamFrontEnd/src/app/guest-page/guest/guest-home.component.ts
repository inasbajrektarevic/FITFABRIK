import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/service/data.service';
import { routerpath } from 'src/app/constants/deafult';

@Component({
  selector: 'app-guest-home',
  templateUrl: './guest-home.component.html',
  styleUrls: ['./guest-home.component.css'],
})
export class GuestHomeComponent implements OnInit {
  obavijesti: any;
  showMore: boolean = false;
  picked: any;
  userId: any;

  constructor(private httpClient: HttpClient, private dataService: DataService) {}

  loadNews() {
    this.httpClient.get(routerpath + '/api/Obavijest').subscribe((res: any) => {
      if (!!res) {
        this.obavijesti = res;
      }
    });
  }

  getSliku(id: number) {
    return `${routerpath}/api/Obavijest/GetSlikaById?id=${id}`;
  }

  readFullContent(id: number) {
    this.httpClient
      .get(`${routerpath}/api/Obavijest/GetById?id=${id}`)
      .subscribe((res) => {
        this.picked = res;
        this.show();
      });
  }

  deletePicked(id: number) {
    const confirmed = confirm('Da li ste sigurni da želite obrisati obavijest?');
    if (!confirmed) {
      return;
    }

    this.httpClient
      .delete(`${routerpath}/api/Obavijest?id=${id}`)
      .subscribe((res) => {
        this.loadNews();
        alert('Uspjesno obrisana obavijest');
      });
  }

  show() {
    this.showMore = !this.showMore;
  }

  ngOnInit() {
    this.loadNews();
    this.userId = this.dataService.korisnik?.id;
  }
}
