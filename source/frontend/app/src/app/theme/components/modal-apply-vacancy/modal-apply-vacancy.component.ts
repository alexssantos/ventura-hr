import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'app-modal-apply-vacancy',
	templateUrl: './modal-apply-vacancy.component.html',
	styleUrls: ['./modal-apply-vacancy.component.scss']
})
export class ModalApplyVacancy implements OnInit {

	//DEVE VIR DO BACKEND
	public Respostas = [1, 2, 3, 4, 5];
	public answerMap = {
		1: "Ruim",
		2: "Regular",
		3: "Bom",
		4: "Muito bom ",
		5: "Excelente",		
	}
	
	public answersData: any[] = [];

	constructor(
		@Inject(MAT_DIALOG_DATA) public vacancy: Vacancy
	) {
		console.log("aplly vacancy", this.vacancy)
	}

	ngOnInit(): void {

	}	

	getTitleAnswer(index: number): string {
		return this.answerMap[index];
	}

	public setAnswer(index: number, id: string, answer: any): void {
		this.answersData[index] = {
			criterioId: id,
			valor: answer
		};		
	}

	checkAnswersOk(): boolean {
		return this.vacancy?.criterios.length == this.answersData?.length;
	}
}
