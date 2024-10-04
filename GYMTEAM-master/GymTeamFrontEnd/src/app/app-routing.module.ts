import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './landing-page/login/login.component';
import { AboutPageComponent } from './landing-page/about/about-page.component';
import { ShopPageComponent } from './landing-page/shop/shop-page.component';
import { LokacijePageComponent } from './landing-page/Lokacije/lokacije-page.component';
import { CjenovnikPageComponent } from './landing-page/Cjenovnik/cjenovnik-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';
import { AdminInfoComponent } from './admin-page/admin-info/admin-info.component';
import { AdminEmployeeComponent } from './admin-page/admin-employee/admin-employee.component';
import { AdminLocationComponent } from './admin-page/admin-location/admin-location.component';
import { PriceListComponent } from './admin-page/price-list/price-list.component';
import { AuthCookieGuard } from './auth-cookie.guard';
import { ErrorPageComponent } from './error-page/error-page.component';
import { EmployeeManagementComponent } from 'src/app/employee-page/employee-management/employee-management.component';
import { GuestComponent } from './guest-page/guest-page.component';
import { AdminGuard } from './admin.guard'; // Uvozite AdminGuard
import { EmployeeGuard } from './employee.guard'; // Uvozite EmployeeGuard
import { GuestGuard } from './guest.guard';
import {EmployeePageComponent} from "./employee-page/employee-page.component"; // Uvozite GuestGuard
import { EmployeeCalculatorComponent } from 'src/app/employee-page/employee-calculator/employee-calculator.component';
import { EmployeeUserComponent } from 'src/app/employee-page/employee-user/employee-user.component';
import { BmiAdviceComponent } from 'src/app/employee-page/bmi-advice/bmi-advice.component';
import { EmployeeProfileComponent } from 'src/app/employee-page/employee-profile/employee-profile.component';
import {GuestHomeComponent} from "./guest-page/guest/guest-home.component";
import {GuestCalculatorComponent} from "./guest-page/guest-calculator/guest-calculator.component";
import {GuestAdviceComponent} from "./guest-page/guest/guest-advice/guest-advice.component";
const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' }, // Default route to login
  { path: 'login', component: LoginComponent }, // Login route

  {
    path: '',
    component: LandingPageComponent,
    children: [
      {
        path: 'about',
        component: AboutPageComponent,
      },
      {
        path: 'shop',
        component: ShopPageComponent,
      },
      {
        path: 'lokacije',
        component: LokacijePageComponent,
      },
      {
        path: 'cjenovnik',
        component: CjenovnikPageComponent,
      },
    ],
  },
  { path: 'error-page', component: ErrorPageComponent },

  {
    path: 'admin',
    component: AdminPageComponent,
    canActivate: [AuthCookieGuard, AdminGuard], // Dodan AdminGuard
    children: [
      {
        path: 'home',
        component: AdminHomeComponent,
      },
      {
        path: 'info',
        component: AdminInfoComponent,
      },
      {
        path: 'employee',
        component: AdminEmployeeComponent,
      },
      {
        path: 'locations',
        component: AdminLocationComponent,
      },
      {
        path: 'price-list',
        component: PriceListComponent,
      },
    ],
  },
  { path: 'employee',
    component: EmployeePageComponent,
    canActivate: [EmployeeGuard] ,
    children:
[
  {
    path: 'management',
    component: EmployeeManagementComponent,

  },
  {
    path: 'calculator',
    component: EmployeeCalculatorComponent,

  },
  {
    path: 'korisnici',
    component: EmployeeProfileComponent,

  },
  {
    path: 'advice',
    component: BmiAdviceComponent,

  },
  {
    path: 'profile',
    component: EmployeeUserComponent,

  },
]},
  {
    path:'guest',
    component:GuestComponent,
    canActivate:[GuestGuard],
    children:
    [
      {
        path:'homepage',
        component: GuestHomeComponent,
      },
      {
        path:'guest-calculator',
        component:GuestCalculatorComponent
      }
      ,
      {
        path:'guest-advice',
        component:GuestAdviceComponent
      }


    ]},




  // Ruta za EmployeeManagement s EmployeeGuard
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
