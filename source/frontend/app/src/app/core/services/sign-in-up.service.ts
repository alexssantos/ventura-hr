import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { catchError, map, tap } from 'rxjs/operators'
import { empty } from 'rxjs/internal/observable/empty';

@Injectable({
	providedIn: 'root'
})
export class SignInUpService {
	private API_URL = environment.API_URL;

	constructor(
		private http: HttpClient,
		private toastr: ToastrService
	) { }

	public SignIn(email, senha): Observable<any> {
		let startRequestToast = this.toastr.info("Login iniciado", "VenturaHR");

		const body = {
			login: email,
			senha: senha
		}
		let url = this.API_URL+ "auth/login";
		return this.http.post(url, body)
			.pipe(
				tap((res) => {
						this.toastr.clear(startRequestToast.toastId)
						this.toastr.success("Login finalizado com secesso", "VenturaHR");
					},
					(error: HttpErrorResponse) => {
						this.toastr.clear(startRequestToast.toastId)

						console.log("error")
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
