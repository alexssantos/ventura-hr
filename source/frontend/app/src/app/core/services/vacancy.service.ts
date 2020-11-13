import { inject } from "@angular/core/testing";

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Injectable({
	providedIn: 'root'
})
export class VacancyService {
	private API_URL = environment.API_URL;
	private baseUrlVacancy = this.API_URL + "/vaga";
	constructor(
		private http: HttpClient,
		private toastr: ToastrService
	) { }

	public createVacancy(newVacancy: Vacancy): Observable<any> {
		let startRequestToast = this.toastr.info("Crating Vacancy iniciado", "VenturaHR");
		
		return this.http.post<Vacancy>(this.baseUrlVacancy, newVacancy)
			.pipe(
				tap((res) => {
					this.toastr.clear(startRequestToast.toastId)
					this.toastr.success("Vaga criada com secesso", "VenturaHR");
				},
					(error: HttpErrorResponse) => {
						this.toastr.clear(startRequestToast.toastId)

						if (error.status == 404) {
							let bodyError = error.error;
							this.toastr.error(bodyError.message, "VenturaHR");
						}
						else {
							this.toastr.error("Erro inesperado", "VenturaHR");
						}
					}),
			)
	}

	public getVacancies(): Observable<Vacancy[]> {
		let startRequestToast = this.toastr.info("buscando vagas", "VenturaHR");

		return this.http.get<Vacancy[]>(this.baseUrlVacancy).pipe(
			//map((result) => result.map(vac => vac as Vacancy)),
			tap(
				(res: Vacancy[]) => {
					this.toastr.clear(startRequestToast.toastId)
					console.log('getVacancies done')
					let totalVacancies = res.length;
					this.toastr.success(`${totalVacancies} vagas encontradas`, "VenturaHR");

					console.table(res);
				},
				(error: HttpErrorResponse) => {
					this.toastr.clear(startRequestToast.toastId)
					if (error.status == 404) {
						let bodyError = error.error;
						this.toastr.error(bodyError.message, "VenturaHR");
					}
					else {
						this.toastr.error("Erro inesperado", "VenturaHR");
					}
				}),
		)
	}

	public searchVacancies(keywords: string[]): Observable<Vacancy[]> {
		let startRequestToast = this.toastr.info("buscando vagas", "VenturaHR");
		
		let params = '?';
		for (let key of Object.keys(keywords)) {
			params += `words=${keywords[key]}&`;
		}
		params = params.slice(0, -1);
		let url = this.baseUrlVacancy + "/busca" + params;
		return this.http.get<Vacancy[]>(url).pipe(		
			tap(
				(res: Vacancy[]) => {
					this.toastr.clear(startRequestToast.toastId)
					console.log('searchVacancies done')
					let totalVacancies = res.length;
					this.toastr.success(`${totalVacancies} vagas encontradas`, "VenturaHR");

					console.table(res);
				},
				(error: HttpErrorResponse) => {
					this.toastr.clear(startRequestToast.toastId)
					if (error.status == 404) {
						let bodyError = error.error;
						this.toastr.error(bodyError.message, "VenturaHR");
					}
					else {
						this.toastr.error("Erro inesperado", "VenturaHR");
					}
				}),
		)
	}
}