import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CijenovnikListComponent } from './cijenovnik-list.component';

describe('CijenovnikListComponent', () => {
  let component: CijenovnikListComponent;
  let fixture: ComponentFixture<CijenovnikListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CijenovnikListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CijenovnikListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
