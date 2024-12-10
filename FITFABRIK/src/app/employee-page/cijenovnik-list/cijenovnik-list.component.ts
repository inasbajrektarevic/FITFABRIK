import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { routerpath } from 'src/app/constants/deafult';

@Component({
  selector: 'app-cijenovnik-list',
  templateUrl: './cijenovnik-list.component.html',
  styleUrls: ['./cijenovnik-list.component.css'],
})
export class CijenovnikListComponent implements OnInit {
  priceList: any;
  showEdit: boolean = false;
  picked: any={};
  planName: string = '';
  planDetails: string = '';
  planPrice: string = '';
  rows: number = 0;
  constructor(private httpClient: HttpClient, private snackbar: MatSnackBar) {}
  loadPriceList() {
    this.httpClient.get(routerpath + '/api/Cjenovnik/GetAll').subscribe((res: any) => {
      if (!!res) {
        this.priceList = res;
      }
    });
  }

  show() {
    this.showEdit = !this.showEdit;
  }
  SaveChanges() {
    const body = {
      nazivStavke: this.picked.nazivStavke,
      opis: this.picked.opis.replace(/\n/g, ''),
      cijena: this.picked.cijena,
      korisnikId: 7,
    };
    let id = this.picked.id;
    this.httpClient
      .put(routerpath + '/api/Cjenovnik?id=' + id, body)
      .subscribe((res) => {
        if (!!res) {
          this.show();
          this.snackbar.open('Izmjene su ažurirane', 'X', {
            duration: 3000,
            panelClass: ['success-snack'],
          });
          this.loadPriceList();
        }
      });
  }
  numberOfRows(opis: string): number {
    let count = 0;
    for (let i = 0; i < opis.length; i++) {
      if (opis[i] === '-') count++;
    }
    return count;
  }
  ngOnInit() {
    this.loadPriceList();
  }
}
