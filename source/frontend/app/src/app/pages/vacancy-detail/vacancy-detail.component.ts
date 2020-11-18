import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
	selector: 'app-vacancy-detail',
	templateUrl: './vacancy-detail.component.html',
	styleUrls: ['./vacancy-detail.component.scss']
})
export class VacancyDetailComponent implements OnInit {
	
	id: string;
	private sub: any;
	
	constructor(
		private route: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.sub = this.route.params.subscribe((params) => {
			this.id = params['id'];
			console.log('details vacancy - id: ', this.id)
		})
	}

}
