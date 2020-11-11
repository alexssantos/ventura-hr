import { Component, Input, OnInit } from '@angular/core';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'job-card',
	templateUrl: './job-card.component.html',
	styleUrls: ['./job-card.component.scss']
})
export class JobCardComponent implements OnInit {

	@Input('cardData') cardVacancy: Vacancy;

	constructor() { }

	ngOnInit(): void {
		console.log(this.cardVacancy);
	}

	public candidateVacancy(): void {

	}

	public goTojobDetails(): void{
		
	}
}
