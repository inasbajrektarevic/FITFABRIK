import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { routerpath } from 'src/app/constants/deafult';

@Component({
  selector: 'app-produkti-list',
  templateUrl: './produkti-list.component.html',
  styleUrls: ['./produkti-list.component.css'],
})
export class ProduktiListComponent implements OnInit {
  productList: any;
  showEdit: boolean = false;
  picked: any={};

  constructor(private httpClient: HttpClient, private snackbar: MatSnackBar) {}

  // Load product list
  loadProductList() {
    this.httpClient.get(routerpath + '/api/Produkt').subscribe((res: any) => {
      if (!!res) {
        this.productList = res;
      }
    });
  }

  // Edit product
  editProduct(id: number) {
    this.httpClient
      .get(`${routerpath}/api/Produkt/GetById?id=` + id)
      .subscribe((res: any) => {
        if (res) {
          this.picked = res; // Assign the fetched product to 'picked'
          this.showEdit = true; // Open the modal for editing
        }
      });
  }

  show() {
    this.showEdit = !this.showEdit;
  }

  // Save changes after editing
  SaveChanges() {
    const body = {
      sifraProdukta: this.picked.sifraProdukta,
      naziv: this.picked.naziv,
      kategorija: this.picked.kategorija,
      cijena: this.picked.cijena,
      zemljaPorijekla: this.picked.zemljaPorijekla,
      masa: this.picked.masa,
    };
    let id = this.picked.id;
    this.httpClient
      .put(routerpath + '/api/Produkt?id=' + id, body)
      .subscribe((res) => {
        if (!!res) {
          this.show();
          this.snackbar.open('Product updated successfully', 'X', {
            duration: 3000,
            panelClass: ['success-snack'],
          });
          this.loadProductList();
        }
      });
  }

  // Delete product
  isLoading = false; // Dodaj ovu promenljivu u klasu



  ngOnInit() {
    this.loadProductList();
  }
}
