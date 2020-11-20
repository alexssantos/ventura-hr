import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';

@Component({
	selector: 'app-vacancy-detail',
	templateUrl: './vacancy-detail.component.html',
	styleUrls: ['./vacancy-detail.component.scss']
})
export class VacancyDetailComponent implements OnInit {
	
	id: string;
	public cardImgBg = '/assets/img/vacancy-details-bg.jpg';
	private sub: any;
	
	constructor(
		private route: ActivatedRoute,
		private sessionService: SessionManagerService
	) { }

	ngOnInit(): void {
		this.sub = this.route.params.subscribe((params) => {
			this.id = params['id'];
			console.log('details vacancy - id: ', this.id)
		})
	}

	public isUserLogged(): boolean {
		return this.sessionService.checkUserLogged();
	}
}
