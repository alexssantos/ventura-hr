import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';
import { ModalApplyVacancy } from 'src/app/theme/components/modal-apply-vacancy/modal-apply-vacancy.component';
import { ModalCreateVacancy } from 'src/app/theme/components/modal-create-vacancy/modal-create-vacancy.component';

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

	public vacancyList: Vacancy[] = [];

	constructor(
		public dialog: MatDialog,
		private vacancyService: VacancyService,
		private sessionService: SessionManagerService
	) { }

	ngOnInit(): void {
		this.loadVacancies();
	}

	public createVacancy(): void{
		const dialogRef = this.dialog.open(ModalCreateVacancy, {
            height: 'auto',
			width: '60%',
			data:  new Vacancy()
        });

    	dialogRef.afterClosed().subscribe((newVacancy: Vacancy) => {
			if (newVacancy)
				this.postVacancy(newVacancy);			
		});		
	}

	public applyVacancy(vacancy: Vacancy): void{
				
		const dialogRef = this.dialog.open(ModalApplyVacancy, {
            height: 'auto',
			width: '60%',
			data: vacancy
        });

    	dialogRef.afterClosed().subscribe((answers: any[]) => {			
			if (answers){
				let body = { criterios: answers	}
				this.postApplyVacancy(vacancy.id, body);
			}
		});		
	}

	public postVacancy(vacancy: Vacancy):void  {
		this.vacancyService.createVacancy(vacancy).subscribe(
			(response) => {
				console.log("Response Create vacancy", response);
			},
			(error) => console.error(error)
		)
	}

	public loadVacancies(): void {
		this.vacancyService.getVacancies().subscribe((list: Vacancy[]) => {
			let listObj: Vacancy[] = list.map((vac) => Object.assign( new Vacancy(), vac));			
			this.vacancyList = listObj;			
		})
	}

	public isCompanyLogged(): boolean {
		return this.sessionService.checkCompanyLogged();
	}

	public searchVacancies(keywords: string[]): void {
		this.vacancyService.searchVacancies(keywords).subscribe((list: Vacancy[]) => {
			let listObj: Vacancy[] = list.map((vac) => Object.assign( new Vacancy(), vac));			
			this.vacancyList = listObj;			
		})
	}	

	private postApplyVacancy(vacancyId: string, body: any): void {
		this.vacancyService.applyVacancy(vacancyId , body).subscribe(
			(response) => {
				console.log("Response Create vacancy", response);
			},
			(error) => console.error(error)
		)
	}
}
