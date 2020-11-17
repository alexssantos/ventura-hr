import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AnimationService } from 'src/app/theme/animations/animation.service';
import { SignInUpService } from './../../core/services/sign-in-up.service';

@Component({
	selector: 'app-sign-in-up',
	templateUrl: './sign-in-up.component.html',
	styleUrls: ['./sign-in-up.component.scss'],
	animations:[
		AnimationService.fadeInTrigger()
	]
})
export class SignInUpComponent implements OnInit {

	public readonly USER_TYPE_ADMIN = 1;
	public readonly USER_TYPE_CANDIDATE = 2;
	public readonly USER_TYPE_COMPANY = 3
	

	signInFrom: FormGroup = new FormGroup({
		login: 		new FormControl('', [Validators.required]),
		password: 	new FormControl('', [Validators.required]),
	});

	signUpForm: FormGroup = new FormGroup({
		name: 		new FormControl('', [Validators.required]),
		login: 		new FormControl('', [Validators.required]),
		password: 	new FormControl('', [Validators.required]),
		email: 		new FormControl('', [Validators.required, Validators.email]),
		birthDate: 	new FormControl('', [Validators.required]),
		typeUser: 	new FormControl('1', [Validators.required]),
		document: 	new FormControl('', [Validators.required]),		
	});
	  
	public isSignIn: boolean = true;

	constructor(
		private SignInUpService: SignInUpService,
		private router: Router
	) { }

	ngOnInit(): void {
	}

	public login():void {
		const {login, password} = this.signInFrom.value;		

		this.SignInUpService.SignIn(login, password).subscribe(
			(res) => {				
				this.router.navigate(['home']);
			},
			(error: HttpErrorResponse) => {	}			
		).add()
	}

	public signUp(): void {
		
		this.SignInUpService.SignUp(this.signUpForm.value).subscribe(
			(res) => {				
				//this.router.navigate(['home']);
				this.isSignIn = true;
			},
			(error: HttpErrorResponse) => {	}
		);
	}	

	public checkTypeUser(): string {
		return this.signUpForm.value.typeUser;
	}

	public switchForm():void {	
		this.isSignIn = !this.isSignIn;	
	}
}
