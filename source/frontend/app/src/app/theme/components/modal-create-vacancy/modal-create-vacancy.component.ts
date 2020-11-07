import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Criterio } from 'src/app/interfaces/criterio.model';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'app-modal-create-vacancy',
	templateUrl: './modal-create-vacancy.component.html',
	styleUrls: ['./modal-create-vacancy.component.scss']
})
export class ModalCreateVacancy implements OnInit {

	//DEVE VIR DO BACKEND
	public Pesos = [1, 2, 3, 4, 5];

	constructor(
		@Inject(MAT_DIALOG_DATA) public newVacancy: Vacancy
	) {
		newVacancy.criterios.push(new Criterio());
	}

	ngOnInit(): void {

	}

	public addCriterio(): void {		
		this.newVacancy.criterios.push(new Criterio());
	}

	public delCriterio(index: number): void {
		this.newVacancy.criterios.splice(index, 1);
		if (this.newVacancy.criterios.length == 0) {
			this.newVacancy.criterios.push(new Criterio());
		}
	}
}
