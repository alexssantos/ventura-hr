import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { VacancyService } from 'src/app/core/services/vacancy.service';

@Component({
	selector: 'app-vacancy-detail',
	templateUrl: './vacancy-detail.component.html',
	styleUrls: ['./vacancy-detail.component.scss']
})
export class VacancyDetailComponent implements OnInit {
	
	id: string;
	public cardImgBg = '/assets/img/vacancy-details-bg.jpg';
	private sub: any;
	public vacancyDetails: any;
	
	constructor(
		private route: ActivatedRoute,
		private sessionService: SessionManagerService,
		private vacancyService: VacancyService
	) { }

	ngOnInit(): void {
		this.sub = this.route.params.subscribe((params) => {
			this.id = params['id'];
			console.log('details vacancy - id: ', this.id)
		})
	}

	public isCandidateLogged(): boolean {
		return this.sessionService.checkCandidateLogged();
	}

	public isCompanyLogged(): boolean {
		return this.sessionService.checkCompanyLogged();
	}

	public checkVacancyFinalized(): boolean{
		return false;
	}

	public finalizeVancancy(): void{
		this.vacancyService.finalizeVacancy(this.id).subscribe(() => {
			(success) => {
				console.log('SUCESSO');
			}
			(error) => {
				console.log('ERROR');
			}
		})
	}
}
