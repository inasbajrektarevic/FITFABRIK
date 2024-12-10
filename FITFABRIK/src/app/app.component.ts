import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core'; // Uvezi TranslateService

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GymTeamFrontEnd';

  constructor(private translate: TranslateService) {
    // Postavi podrazumevani jezik
    this.translate.setDefaultLang('en'); // Postavi engleski kao podrazumevani jezik
  }

  // Metod za promenu jezika
  changeLanguage(lang: string) {
    console.log("Promena jezika na: " + lang); // Proveri u konzoli da li je metoda pozvana
    this.translate.use(lang); // Promeni jezik na željeni
  }
}
