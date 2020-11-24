import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalApplyVacancyComponent } from './modal-apply-vacancy.component';

describe('ModalApplyVacancyComponent', () => {
  let component: ModalApplyVacancyComponent;
  let fixture: ComponentFixture<ModalApplyVacancyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalApplyVacancyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalApplyVacancyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
