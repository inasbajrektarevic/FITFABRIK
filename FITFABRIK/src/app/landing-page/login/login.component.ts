import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth/auth.service';
import { IUser } from 'src/app/service/models/user';
import { DataService } from 'src/app/service/data.service';
import { take, timer } from 'rxjs';
import { COOKIE_USER_DATA } from "../../constants/deafult";
import { CookieService } from "ngx-cookie-service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  forma: FormGroup = new FormGroup({
    email: new FormControl(''),
    lozinka: new FormControl(''),
  });

  isLoading: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackbar: MatSnackBar,
    private dataService: DataService,
    private cookie: CookieService
  ) {}

  ngOnInit(): void {}

  loginUser({ email, lozinka }: Partial<IUser>) {
    if (!!email && !!lozinka) {
      this.isLoading = true; // Postavi isLoading na true

      this.authService.login({ email, lozinka }).subscribe(
        (loggedIn) => {
          if (loggedIn) {
            // Simuliraj kašnjenje od 2 sekunde prije preusmjeravanja na drugu stranicu
            timer(2000)
              .pipe(take(1))
              .subscribe(() => {
                const userData = this.authService.getUserData(); // Dobij korisničke podatke
                if (userData) {
                  switch (userData.roleId) {
                    case 1: // Uloga Admin
                      this.router.navigate(['admin/home']);
                      break;
                    case 2: // Uloga Employee
                      this.router.navigate(['employee/management']); // Promijeni putanju za zaposlenika
                      break;
                    case 3: // Uloga Guest
                      this.router.navigate(['guest/homepage']); // Promijeni putanju za gosta
                      break;
                    default:
                      this.snackbar.open('Uloga korisnika nije prepoznata', 'X', {
                        duration: 1000,
                        panelClass: ['error-snack'],
                      });
                  }
                }
                this.dataService.updateKorisnik();
              });
          } else {
            this.snackbar.open('Neispravni podaci za prijavu', 'X', {
              duration: 1000,
              panelClass: ['error-snack'],
            });
          }
          this.isLoading = false; // Postavi isLoading na false nakon što se završi login zahtjev
        },
        (error) => {
          console.error('Login failed:', error);
          this.snackbar.open('Greška prilikom prijave', 'X', {
            duration: 1000,
            panelClass: ['error-snack'],
          });
          this.isLoading = false; // Postavi isLoading na false ako je login zahtjev neuspio
        }
      );
    } else {
      this.snackbar.open('Neispravni podaci za prijavu', 'X', {
        duration: 1000,
        panelClass: ['error-snack'],
      });
    }
  }
}
