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
		private SignInUpService: SignInUpService,
		private toastr: ToastrService
	) { }

	ngOnInit(): void {
	}

	public login():void {

		this.toastr.info("Login iniciado", "VenturaHR");
		this.SignInUpService.SignIn(this.loginForm.email, this.loginForm.senha).subscribe(
			(res) => {
				console.log(res);
				this.toastr.success("Login finalizado com secesso", "VenturaHR");
			},
			(error) => {
				console.log(error);
				this.toastr.error("Login finalizado com erro", "VenturaHR");
			}
		);
	}
}
