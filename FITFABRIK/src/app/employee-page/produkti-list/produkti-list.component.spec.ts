import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProduktiListComponent } from './produkti-list.component';

describe('ProduktiListComponent', () => {
  let component: ProduktiListComponent;
  let fixture: ComponentFixture<ProduktiListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProduktiListComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ProduktiListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
