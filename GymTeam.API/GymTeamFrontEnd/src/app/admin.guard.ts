import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/service/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // Provjeravamo da li je korisnik admin
    if (this.authService.isAdmin()) {
      return true; // Ako je korisnik admin, dozvoli pristup
    } else {
      // Ako nije admin, preusmjeri na neku drugu stranicu, npr. home
      return this.router.createUrlTree(['/home']);
    }
  }
}
