import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './landing-page/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { SideMenuComponent  as SMC1}  from './admin-page/side-menu/side-menu.component';
import {SideMenuComponent as SMC2} from "./employee-page/side-menu/side-menu.component";
import { AdminHomeComponent } from './admin-page/admin-home/admin-home.component';
import { AdminInfoComponent } from './admin-page/admin-info/admin-info.component';
import { AdminEmployeeComponent } from './admin-page/admin-employee/admin-employee.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { EmployeedataComponent } from './admin-page/admin-employee/employeedata/employeedata.component';
import { AddUserComponent } from './admin-page/admin-employee/add-user/add-user.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { AdminLocationComponent } from './admin-page/admin-location/admin-location.component';
import { PriceListComponent } from './admin-page/price-list/price-list.component';
import { LoadingsvgComponent } from './service/loadingsvg/loadingsvg.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { LokacijePageComponent } from './landing-page/Lokacije/lokacije-page.component';
import { EmployeeManagementComponent } from 'src/app/employee-page/employee-management/employee-management.component';
import {EmployeePageComponent} from "src/app/employee-page/employee-page.component";
import {
  EmployeeCalculatorComponent,
} from "./employee-page/employee-calculator/employee-calculator.component";
import {EmployeeUserComponent} from "./employee-page/employee-user/employee-user.component";
import {BmiAdviceComponent} from "./employee-page/bmi-advice/bmi-advice.component";
import {EmployeeProfileComponent} from "./employee-page/employee-profile/employee-profile.component";
import {NavMenuComponent} from "./guest-page/nav-menu/nav-menu.component";
import {GuestComponent} from "./guest-page/guest-page.component";
import {GuestHomeComponent} from "src/app/guest-page/guest/guest-home.component";
import {GuestCalculatorComponent} from "src/app/guest-page/guest-calculator/guest-calculator.component";
import {GuestAdviceComponent} from "src/app/guest-page/guest/guest-advice/guest-advice.component";
@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    LoginComponent,
    AdminPageComponent,
    SMC1,SMC2,
    AdminHomeComponent,
    AdminInfoComponent,
    EmployeedataComponent,
    EmployeePageComponent,GuestHomeComponent,GuestCalculatorComponent,
    AddUserComponent,
    EmployeeUserComponent,GuestComponent,
    AdminEmployeeComponent,
    AdminLocationComponent,
    PriceListComponent,
    LoadingsvgComponent,
    LokacijePageComponent,NavMenuComponent,
    EmployeeCalculatorComponent,
    ErrorPageComponent,GuestAdviceComponent,
    EmployeeManagementComponent,
    GuestComponent,
    BmiAdviceComponent,EmployeeProfileComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatDialogModule,
    MatInputModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
