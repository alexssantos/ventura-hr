import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SignInUpService } from './../../core/services/sign-in-up.service';

@Component({
	selector: 'app-sign-in-up',
	templateUrl: './sign-in-up.component.html',
	styleUrls: ['./sign-in-up.component.scss']
})
export class SignInUpComponent implements OnInit {

	public loginForm = {
		email: "",
		senha:""
	}

	constructor(
		private SignInUpService: SignInUpService		
	) { }

	ngOnInit(): void {
	}

	public login():void {
		

		this.SignInUpService.SignIn(this.loginForm.email, this.loginForm.senha).subscribe(
			(res) => {				
				console.log("sucesso: ", res);
			},
			(error: HttpErrorResponse) => {	
				console.log("Erro: ", error);
			}			
		).add()
	}
}
