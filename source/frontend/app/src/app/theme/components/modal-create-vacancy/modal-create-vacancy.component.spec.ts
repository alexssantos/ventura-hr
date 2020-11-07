import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCreateVacancy } from './modal-create-vacancy.component';

describe('ModalCreateVacancy', () => {
  let component: ModalCreateVacancy;
  let fixture: ComponentFixture<ModalCreateVacancy>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalCreateVacancy ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalCreateVacancy);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
