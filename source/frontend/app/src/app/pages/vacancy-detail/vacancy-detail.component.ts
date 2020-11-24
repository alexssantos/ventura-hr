import { Component, OnInit } from '@angular/core';
import { EmailValidator } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';
import { ModalApplyVacancy } from 'src/app/theme/components/modal-apply-vacancy/modal-apply-vacancy.component';


export interface RankedCandidate {
	position: number;
	name: string;
	email: number;
	score: string;
	tel: string;
}


@Component({
	selector: 'app-vacancy-detail',
	templateUrl: './vacancy-detail.component.html',
	styleUrls: ['./vacancy-detail.component.scss']
})
export class VacancyDetailComponent implements OnInit {
	displayedColumns: string[] = ['position', 'score', 'email', 'name', 'tel'];
	candidateList = [];

	id: string;
	public criationDate: Date;
	public totalCandidatos: number = 0;
	public vacancy: Vacancy;
	public cardImgBg = '/assets/img/vacancy-details-bg.jpg';
	public vacancyDetails: any;
	public AmountDaysOffCreated: number = 0;

	constructor(
		private route: ActivatedRoute,
		private sessionService: SessionManagerService,
		private vacancyService: VacancyService,
		private router: Router,
		public dialog: MatDialog,
	) {
		this.route.params.subscribe((params) => {
			this.id = params['id'];
		});		

		const state = this.router.getCurrentNavigation().extras.state;
		if (state) {
			this.vacancy = state.vacancyData;
			this.criationDate = new Date(this.vacancy.dataCriacao);
		}
		//caso pagina recarregada com F5
		else {
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

	public isLogged(): boolean {
		return this.sessionService.checkUserLogged();
	}

	public checkVacancyFinalized(): boolean {
		return (this.vacancy) ? false : true;
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
			(res) => {
				console.log('SUCESSO getVacancyDetail');
				this.vacancyDetails = res.data;
				let candidates = res.data.candidatos;
				if (candidates && candidates.length > 0) {
					this.candidateList = this.extractCandidateList(candidates);					
				}
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
				this.criationDate = new Date(this.vacancy.dataCriacao);
			},
			(error) => {
				console.log('ERROR getVacancyById');
			}
		)
	}

	public isCriterioLoaded(): boolean {
		return (this.vacancy?.criterios) && (this.vacancy?.criterios.length > 0);
	}

	public getAmountDaysOffCreated(): number {
		let dateValue = this.vacancy?.dataCriacao;
		let daysDiff = (dateValue)
			? this.DaysDiff(new Date(dateValue))
			: 0;
		return daysDiff;
	}

	private DaysDiff(date1: Date): number {
		let today = new Date();
		var diff = Math.abs(date1.getTime() - today.getTime());
		var diffDays = Math.round(diff / (1000 * 3600 * 24));
		return diffDays;
	}

	private extractCandidateList(list: any[]): RankedCandidate[] {
		let rankedItens = list.map((item, index) => {
			let mappedItem: RankedCandidate = {
				email: item.email,
				tel: item.telefone,
				name: item.nome,
				score: item.pontuacao,
				position: index+1
			}
			return mappedItem;
		});		
		return rankedItens;
	}

	public getAmountAppliers(): any {
		return (this.vacancy) ? this.vacancy.respostas.length : "---";
	}

	public applyVacancy(): void{
				
		const dialogRef = this.dialog.open(ModalApplyVacancy, {
            height: 'auto',
			width: '60%',
			data: this.vacancy
        });

    	dialogRef.afterClosed().subscribe((answers: any[]) => {			
			if (answers){
				let body = { criterios: answers	}
				this.postApplyVacancy(this.vacancy.id, body);
			}
		});		
	}

	private postApplyVacancy(vacancyId: string, body: any): void {
		this.vacancyService.applyVacancy(vacancyId , body).subscribe(
			(response) => {
				console.log("Response Create vacancy", response);
			},
			(error) => console.error(error)
		)
	}

	public isMinimumProfileScore(score: number): boolean{
		return score > this.vacancyDetails.perfilMinimoDesejado;
	}
}
