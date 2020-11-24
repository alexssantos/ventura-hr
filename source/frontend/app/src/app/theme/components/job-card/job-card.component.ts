import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'job-card',
	templateUrl: './job-card.component.html',
	styleUrls: ['./job-card.component.scss']
})
export class JobCardComponent implements OnInit {

	@Input('cardData') cardVacancy: Vacancy;
	@Output('applyBtn') applyEvent: EventEmitter<Vacancy> = new EventEmitter();
	public mouseOver: boolean;

	constructor(
		private sessionService: SessionManagerService,
		private router: Router
	) { }

	ngOnInit(): void {
	}

	public goTojobDetails(): void{
		this.router.navigate(['/vacancy', this.cardVacancy.id] ,{
			state: { vacancyData: this.cardVacancy }
		});
	}

	public isCandidateLogged(){
		return this.sessionService.checkCandidateLogged()
	}

	public isMouseOver(state: boolean): void{
		this.mouseOver = state;
	}

	public applyVacancy(): void {
		this.applyEvent.emit(this.cardVacancy);		
	}
}
