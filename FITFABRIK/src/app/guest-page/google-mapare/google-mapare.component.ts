import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Map } from 'mapbox-gl';
import * as mapboxgl from 'mapbox-gl';
import { take, timer } from 'rxjs';

import { routerpath } from 'src/app/constants/deafult';
import { MAPBOX_ACCESS_TOKEN } from 'src/app/service/mapbox.config';
@Component({
  selector: 'app-google-mapare',
  templateUrl: './google-mapare.component.html',
  styleUrls: ['./google-mapare.component.css'],
})
export class GoogleMapareComponent implements OnInit {
  forma: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
  });
  locations: any;
  selectedLocation: any;
  showMore: boolean = false;
  openNew: boolean = false;
  photo: any;
  latitude: number = 0;
  longitude: number = 0;
  isLoading: boolean = false;
  constructor(private httpClient: HttpClient, private snackbar: MatSnackBar) {}

  ngOnInit(): void {
    this.GetLocations();
  }
  GetLocations(): void {
    this.httpClient.get(routerpath + '/api/Lokacija').subscribe((res) => {
      if (!!res) this.locations = res;
    });
  }
  getImage(id: number) {
    return `${routerpath}/api/Lokacija/GetSlikaById?id=${id}`;
  }
  openClose() {
    this.showMore = !this.showMore;
  }

  viewMore(id: number) {
    this.openClose();
    this.httpClient
      .get(`${routerpath}/api/Lokacija/GetbyId?id=${id}`)
      .subscribe((res) => {
        if (!!res) {
          this.selectedLocation = res;
          const longitude = this.selectedLocation.longitude;
          const latitude = this.selectedLocation.latitude;

          const map = new Map({
            accessToken: MAPBOX_ACCESS_TOKEN,
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11',
            center: [longitude, latitude],
            zoom: 12,
          });
          const marker = new mapboxgl.Marker()
            .setLngLat([longitude, latitude])
            .addTo(map);
        }
      });
  }
  onFileChange(event: any) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.photo = reader.result;
      };
    }
  }
  addNew() {
    this.openNew = true;
    this.forma.controls['name'].reset('');
    this.isLoading = false;
    setTimeout(() => {
      const map = new Map({
        accessToken: MAPBOX_ACCESS_TOKEN,
        container: 'mapAdd',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [17.8357, 44.1623],
        zoom: 12,
      });
      const clickListener = (e: any) => {
        this.latitude = e.lngLat.lat;
        this.longitude = e.lngLat.lng;

        const marker = new mapboxgl.Marker()
          .setLngLat([this.longitude, this.latitude])
          .addTo(map);

        map.off('click', clickListener);
      };

      map.on('click', clickListener);
    }, 0);
  }
  saveChanges() {
    this.isLoading = true;

    const body = {
      naziv: this.forma.value.name,
      adresaId: 2,
      latitude: this.latitude,
      longitude: this.longitude,
      slika: this.photo,
    };
    if (this.forma.valid) {
      this.httpClient
        .post(routerpath + '/api/Lokacija', body)
        .subscribe((res) => {
          if (!!res) {
            timer(3000)
              .pipe(take(1))
              .subscribe(() => {
                this.isLoading = true;
                this.snackbar.open('Uspjesno dodana nova lokacija', 'X', {
                  duration: 3000,
                  panelClass: ['success-snack'],
                });
                this.GetLocations();
                this.openNew = false;
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
  deleteLocation(id: number) {
    const confirmed = confirm(
      'Da li ste sigurni da želite obrisati ovu lokaciju?'
    );
    if (!confirmed) {
      return;
    }

    this.httpClient
      .delete(`${routerpath}/api/Lokacija?id=${id}`)
      .subscribe((res) => {
        if (!!res) {
          this.GetLocations();
          this.openClose();
          this.snackbar.open('Uspjesno obrisana lokacija', 'X', {
            duration: 3000,
            panelClass: ['success-snack'],
          });
        }
      });
  }
}
