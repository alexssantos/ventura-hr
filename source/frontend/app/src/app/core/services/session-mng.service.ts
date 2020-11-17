import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class SessionManagerService {
	
	private readonly TYPE_USAR_KEY = 'type_user';
	private readonly TOKEN_KEY = 'token_access';


	constructor() {		
		
	}

	public setTypeUser(typeUser: any): void {
		sessionStorage.setItem(this.TYPE_USAR_KEY, typeUser);
	}
	public getTypeUser(): any {
		return sessionStorage.getItem(this.TYPE_USAR_KEY);
	}

	public setToken(token: string): void {
		sessionStorage.setItem(this.TOKEN_KEY, token);
	}
	public getToken(): string {
		return sessionStorage.getItem(this.TOKEN_KEY);
	}

	public checkUserLogged(): boolean {
		let token = this.getToken();
		return  (token) ? true : false;
	}

	public checkCandidateLogged(): boolean{
		return this.checkUserLogged() && this.getTypeUser() == 2;
	}
	
	public checkCompanyLogged(): boolean{
		return this.checkUserLogged() && this.getTypeUser() == 3;
	}
}