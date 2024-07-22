import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AddUserComponent } from './add-user/add-user.component';
import { EmployeedataComponent } from './employeedata/employeedata.component';
import { routerpath } from 'src/app/constants/deafult';
import { UserData } from '../../service/models/usersData';

@Component({
  selector: 'app-admin-employee',
  templateUrl: './admin-employee.component.html',
  styleUrls: ['./admin-employee.component.css'],
})
export class AdminEmployeeComponent implements OnInit {
  ime: string = '';
  prezime: string = '';
  lokacijaid: number = 0;
  employee: any;
  ime_prezime: string = '';
  page: number = 1;
  numberOfPages: number = 0;
  pageSize: number = 6;
  korisnik: any;
  constructor(
    private httpClient: HttpClient,
    private snackbar: MatSnackBar,
    private dialogRef: MatDialog
  ) {}

  ngOnInit(): void {
    this.FetchEmployees(this.ime_prezime);
  }

  Filtriraj() {
    this.FetchEmployees(this.ime_prezime);
  }

  FetchEmployees(ime_prezime?: string, page = 1, pageSize = 6): void {
    console.log(`Fetching employees with name: ${ime_prezime}, page: ${page}, pageSize: ${pageSize}`);

    this.httpClient
      .get<UserData>(
        `${routerpath}/api/Korisnik?ime_prezime=${ime_prezime}&page=${page}&pageSize=${pageSize}`
      )
      .subscribe((res) => {
        console.log('FetchEmployees response:', res);

        if (!!res) {
          this.employee = res.data;
          this.numberOfPages = res.totalPages;
        }
      }, (error) => {
        console.error('Error fetching employees:', error);
      });
  }

  Obrisi(id: number): void {
    const confirmed = confirm(
      'Da li ste sigurni da želite obrisati ovog korisnika?'
    );
    if (!confirmed) {
      return;
    }

    console.log(`Deleting user with ID: ${id}`);

    try {
      this.httpClient
        .delete(`${routerpath}/api/Korisnik?id=${id}`)
        .subscribe((res) => {
          console.log('Delete response:', res);
          if (res) this.FetchEmployees(this.ime_prezime);
        }, (error) => {
          console.error('Error deleting user:', error);
        });
    } catch (error) {
      console.error('Unexpected error:', error);
    } finally {
      this.snackbar.open('Korisnik uspjesno obrisan', 'X', {
        duration: 3000,
        panelClass: ['success-snack'],
      });
    }
  }

  openForm(korisnik: any): void {
    console.log('Opening form for user:', korisnik);
    this.dialogRef.open(EmployeedataComponent, {
      data: { korisnik },
      panelClass: ['formica'],
    });
  }

  openAddUserForm(): void {
    console.log('Opening add user form');

    this.dialogRef
      .open(AddUserComponent, {
        panelClass: ['addUser'],
      })
      .afterClosed()
      .subscribe(() => this.FetchEmployees(this.ime_prezime));
  }

  getSliku(id: number) {
    const imageUrl = `${routerpath}/api/Korisnik/GetSlikaById?id=${id}`;
    return imageUrl;
  }

  previousPage() {
    if (this.page > 1) {
      console.log('Navigating to previous page');
      this.page--;
      this.FetchEmployees(this.ime_prezime, this.page, 6);
    }
  }

  nextPage() {
    if (this.page < this.numberOfPages) {
      console.log('Navigating to next page');
      this.page++;
      this.FetchEmployees(this.ime_prezime, this.page, 6);
    }
  }
}
