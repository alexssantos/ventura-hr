import { inject } from "@angular/core/testing";

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Vacancy } from 'src/app/interfaces/vacancy.model';

@Injectable({
	providedIn: 'root'
})
export class VacancyService {
	private API_URL = environment.API_URL;

	constructor(
		private http: HttpClient,
		private toastr: ToastrService
	) { }

	public createVacancy(newVacancy: Vacancy): Observable<any> {
		let startRequestToast = this.toastr.info("Crating Vacancy iniciado", "VenturaHR");

		let url = this.API_URL+ "/vaga";
		return this.http.post<Vacancy>(url, newVacancy)
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
						else{
							this.toastr.error("Erro inesperado", "VenturaHR");
						}
					}),
			)
	}
}