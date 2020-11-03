import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SignInUpService } from './../../core/services/sign-in-up.service';

@Component({
	selector: 'app-sign-in-up',
	templateUrl: './sign-in-up.component.html',
	styleUrls: ['./sign-in-up.component.scss']
})
export class SignInUpComponent implements OnInit {

	signInFrom: FormGroup = new FormGroup({
		username: new FormControl('', [Validators.required]),
		password: new FormControl('', [Validators.required]),
	});
	  
	public isSignIn: boolean = true;

	constructor(
		private SignInUpService: SignInUpService,
		private router: Router
	) { }

	ngOnInit(): void {
	}

	public login():void {
		const {username, password} = this.signInFrom.value;
		this.SignInUpService.SignIn(username, username).subscribe(
			(res) => {				
				this.router.navigate(['home']);
			},
			(error: HttpErrorResponse) => {	}			
		).add()
	}

	public signUpPage():void {
		this.isSignIn = false;
	}
}
