import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { routerpath } from 'src/app/constants/deafult';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
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

  deleteProduct(id: number) {
    if (confirm('Are you sure you want to delete this product?')) {
      this.isLoading = true; // Prikazuje indikator učitavanja
      const url = `${routerpath}/api/Produkt?id=${id}`;

      this.httpClient.delete(url, { responseType: 'text' }).subscribe(
        (res) => {
          this.isLoading = false; // Uklanja indikator učitavanja
          // Provera da li je odgovor validan
          if (res === 'Produkt je obrisan') {
            this.productList = this.productList.filter((product: any) => product.id !== id);
            this.snackbar.open('Product deleted successfully', 'X', {
              duration: 3000,
              panelClass: ['success-snack'],
            });
          } else {
            this.snackbar.open('Unexpected response from the server', 'X', {
              duration: 3000,
              panelClass: ['error-snack'],
            });
          }
        },
        (error) => {
          this.isLoading = false;
          console.error(error); // Loguje grešku u konzoli za dalju analizu
          this.snackbar.open('Error deleting product', 'X', {
            duration: 3000,
            panelClass: ['error-snack'],
          });
        }
      );
    }
  }

  ngOnInit() {
    this.loadProductList();
  }
}
