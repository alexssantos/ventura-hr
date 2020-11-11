import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/interfaces/vacancy.model';
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
		private vacancyService: VacancyService
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
}
