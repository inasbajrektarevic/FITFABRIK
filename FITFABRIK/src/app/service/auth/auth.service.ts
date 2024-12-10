import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { LOGIN } from '../endpoints';
import { ILoginResponse } from '../models/login';
import { IUser } from '../models/user';
import { IAuth } from '../models/login';
import { COOKIE_USER_DATA, TOKEN_DATA, USER_DATA, routerpath } from 'src/app/constants/deafult';
import { Observable, catchError, map, of } from 'rxjs';
import { Uloga, getRoleName } from 'src/app/service/models/role'; // Adjust the import path accordingly

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient, private cookie: CookieService) {}

  login({ email, lozinka }: Partial<IUser>): Observable<boolean> {
    return this.httpClient
      .post<ILoginResponse>(`${routerpath}${LOGIN}`, { email, lozinka })
      .pipe(
        map((response) => {
          if (response && response.autentifikacijaToken) {
            const { korisnik, korisnikId, ...token } = response.autentifikacijaToken;
            const cookieSettings = {
              domain: 'localhost',
            };
            this.cookie.set(COOKIE_USER_DATA, JSON.stringify(korisnik.id), {
              ...cookieSettings,
            });
            sessionStorage.setItem(TOKEN_DATA, JSON.stringify(token));
            console.log('User Object:', korisnik); // Debug: Prikaži korisnički objekat

            // Spremanje roleId i korisničkog objekta
            const userWithRole = { ...korisnik, roleId: response.autentifikacijaToken.roleId };
            sessionStorage.setItem(USER_DATA, JSON.stringify(userWithRole)); // Spremanje cijelog korisničkog objekta
            this.setSessionStorage(userWithRole); // Poziv metode za postavljanje sesije
            return true;
          }
          return false;
        }),
        catchError((error) => {
          console.error(error);
          return of(false);
        })
      );
  }

  setSessionStorage(userData: {
    ime?: string;
    prezime?: string;
    lozinka?: string;
    roleId: number; // Prilagođeno da uključuje roleId
    datumRodjenja?: string;
    putanjaSlike?: string;
    brojTelefona?: string;
    id?: number;
    email?: string;
  }) {
    const userDataString = sessionStorage.getItem(USER_DATA);
    console.log('User Data String:', userDataString); // Debug: Prikaži pohranjeni string
    if (userDataString) {
      const userData = JSON.parse(userDataString);
      console.log('Parsed User Data:', userData); // Debug: Prikaži parsirani objekat
      if (userData && userData.roleId !== undefined) {
        const roleName = getRoleName(userData.roleId); // Pristup ulozi korisnika
        console.log('User Role:', roleName); // Ispis imena uloge korisnika
      } else {
        console.error('User role not found in user data');
      }
    } else {
      console.error('User data string not found in session storage');
    }
  }

  // Metode za provjeru uloga
  isAdmin(): boolean {
    const userData = this.getUserData();
    return userData?.roleId === Uloga.Admin;
  }

  isEmployee(): boolean {
    const userData = this.getUserData();
    return userData?.roleId === Uloga.Employee;
  }

  isGuest(): boolean {
    const userData = this.getUserData();
    return userData?.roleId === Uloga.GuestUser;
  }

  public getUserData(): { roleId: number } | null {
    const userDataString = sessionStorage.getItem(USER_DATA);
    if (userDataString) {
      return JSON.parse(userDataString);
    }
    return null;
  }
}
