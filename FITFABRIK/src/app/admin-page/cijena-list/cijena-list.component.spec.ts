import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CijenaListComponent } from './cijena-list.component';

describe('CijenaListComponent', () => {
  let component: CijenaListComponent;
  let fixture: ComponentFixture<CijenaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CijenaListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CijenaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
