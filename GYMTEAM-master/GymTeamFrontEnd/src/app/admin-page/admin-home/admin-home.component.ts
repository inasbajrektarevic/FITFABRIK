import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { take, timer } from 'rxjs';
import {COOKIE_USER_DATA, routerpath} from 'src/app/constants/deafult';
import { DataService } from 'src/app/service/data.service';
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css'],
})
export class AdminHomeComponent implements OnInit {
  forma: FormGroup = new FormGroup({
    title: new FormControl('', Validators.required),
    type: new FormControl('', Validators.required),
    content: new FormControl('', Validators.required),
    photo: new FormControl(null, Validators.required),
  });
  success: boolean = false;
  obavijesti: any;
  showMore: boolean = false;
  picked: any;
  isLoading: boolean = false;
  userId: any;
  constructor(
    private httpClient: HttpClient,
    private snackbar: MatSnackBar,
    private cookie: CookieService,
    private dataService: DataService
  ) {}
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
  onFileChange(event: any) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.forma.value.photo = reader.result;
      };
    }
  }

  addNew() {
    this.isLoading = true;
    const tokenData = sessionStorage.getItem("TOKEN_DATA");
    const cookieValue = this.cookie.get(COOKIE_USER_DATA);

      let userId = JSON.parse(cookieValue);
    // @ts-ignore
    // @ts-ignore
    // @ts-ignore
    // @ts-ignore
    // @ts-ignore
    const body = {
      naslov: this.forma.value.title,
      tip: this.forma.value.type,
      sadrzaj: this.forma.value.content,
      korisnikId: userId,

      slika: this.forma.value.photo,
    };
    if (this.forma.valid) {
      this.httpClient
        .post(routerpath + '/api/Obavijest', body)
        .subscribe((res) => {
          if (!!res) {
            timer(3000)
              .pipe(take(1))
              .subscribe(() => {
                this.isLoading = true;
                this.snackbar.open('Uspjesno dodana nova obavijest', 'X', {
                  duration: 3000,
                  panelClass: ['success-snack'],
                });
                this.loadNews();
                this.success = false;
              });
          } else
            this.snackbar.open('Greska', 'X', {
              duration: 1000,
              panelClass: ['error-snack'],
            });
        });
    } else {
      this.isLoading = false;
      this.snackbar.open('Popunite sva polja', 'X', {
        duration: 1000,
        panelClass: ['error-snack'],
      });
    }
  }
  readFullContent(id: number) {
    this.httpClient
      .get(`${routerpath}/api/Obavijest/GetById?id=${id}`)
      .subscribe((res) => {
        this.picked = res;
        this.show();
      });
  }
  openClose() {
    this.forma.controls['title'].reset('');
    this.forma.controls['type'].reset('');
    this.forma.controls['content'].reset('');
    this.isLoading = false;
    this.success = !this.success;
  }
  deletePicked(id: number) {
    const confirmed = confirm(
      'Da li ste sigurni da želite obrisati obavijest?'
    );
    if (!confirmed) {
      return;
    }

    this.httpClient
      .delete(`${routerpath}/api/Obavijest?id=${id}`)
      .subscribe((res) => {
        this.show();
        this.loadNews();
        this.snackbar.open('Uspjesno obrisana obavijest', 'X', {
          duration: 3000,
          panelClass: ['success-snack'],
        });
      });
  }
  show() {
    this.showMore = !this.showMore;
  }
  ngOnInit() {
    this.loadNews();
    this.userId = this.dataService.korisnik?.id;
    console.log(this.userId);
  }
}
