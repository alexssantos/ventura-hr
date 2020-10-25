import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
	providedIn: 'root'
})
export class SignInUpService {
	private API_URL = environment.API_URL;

	constructor(
		private http: HttpClient
	) { }

	public SignIn(form: any): Observable<any> {
		let url = this.API_URL+ "usuario/cadastro";
		return this.http.post(url, form);
	}
}
