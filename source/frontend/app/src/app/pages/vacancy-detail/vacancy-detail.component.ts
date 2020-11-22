import { dashCaseToCamelCase } from '@angular/compiler/src/util';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Component({
	selector: 'app-vacancy-detail',
	templateUrl: './vacancy-detail.component.html',
	styleUrls: ['./vacancy-detail.component.scss']
})
export class VacancyDetailComponent implements OnInit {

	id: string;
	public totalCandidatos: number = 0;
	public vacancy: Vacancy;
	public cardImgBg = '/assets/img/vacancy-details-bg.jpg';
	public vacancyDetails: any;
	public AmountDaysOffCreated: number= 0;	

	constructor(
		private route: ActivatedRoute,
		private sessionService: SessionManagerService,
		private vacancyService: VacancyService,
		private router: Router
	) {
		this.route.params.subscribe((params) => {
			this.id = params['id'];
		});
		console.log(this.id);

		const state = this.router.getCurrentNavigation().extras.state;
		if (state) {			
			this.vacancy = state.vacancyData;			
		}
		//caso pagina recarregada com F5
		else{
			this.getVacancyById(this.id);
		}
	}

	ngOnInit(): void {
		if (this.isCompanyLogged()) {
			this.getVacancyDetail();
		}
	}

	public isCandidateLogged(): boolean {
		return this.sessionService.checkCandidateLogged();
	}

	public isCompanyLogged(): boolean {
		return this.sessionService.checkCompanyLogged();
	}

	public checkVacancyFinalized(): boolean {
		return false;
	}

	public finalizeVancancy(): void {
		this.vacancyService.finalizeVacancy(this.id).subscribe(
			(success) => {
				console.log('SUCESSO');
				this.router.navigate(['/home']);
			},
			(error) => {
				console.log('ERROR');
			}
		)
	}

	public getVacancyDetail(): void {
		this.vacancyService.getVacancyDetail(this.id).subscribe(
			(success) => {
				console.log('SUCESSO getVacancyDetail');				
			},
			(error) => {
				console.log('ERROR getVacancyDetail');
			}
		)
	}

	public getVacancyById(vacancyId: string): void {
		this.vacancyService.getVacancyById(vacancyId).subscribe(
			(success) => {
				console.log('SUCESSO getVacancyById');
				this.vacancy = success as Vacancy;
			},
			(error) => {
				console.log('ERROR getVacancyById');
			}
		)
	}

	public isCriterioLoaded(): boolean {		
		return (this.vacancy?.criterios) && (this.vacancy?.criterios.length > 0);
	}

	public getAmountDaysOffCreated():number{
		let dateValue = this.vacancy?.dataCriacao;
		let daysDiff = (dateValue) 
			? this.DaysDiff(new Date(dateValue)) 
			: 0;
		return daysDiff;
	}

	private DaysDiff(date1: Date): number{
		let today = new Date();
		var diff = Math.abs(date1.getTime() - today.getTime());
		var diffDays = Math.round(diff / (1000 * 3600 * 24)); 
		return diffDays;
		
	}
}
