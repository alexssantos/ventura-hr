import { Component, Input, OnInit } from '@angular/core';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'job-card',
	templateUrl: './job-card.component.html',
	styleUrls: ['./job-card.component.scss']
})
export class JobCardComponent implements OnInit {

	@Input('cardData') cardVacancy: Vacancy;
	public mouseOver: boolean;

	constructor(
		private sessionService: SessionManagerService
	) { }

	ngOnInit(): void {
	}

	public candidateVacancy(): void {

	}

	public goTojobDetails(): void{
		
	}

	public isCandidateLogged(){
		return this.sessionService.checkCandidateLogged()
	}

	public isMouseOver(state: boolean): void{
		this.mouseOver = state;
	}
}
