import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CijeneListComponent } from './cijene-list.component';

describe('CijeneListComponent', () => {
  let component: CijeneListComponent;
  let fixture: ComponentFixture<CijeneListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CijeneListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CijeneListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
