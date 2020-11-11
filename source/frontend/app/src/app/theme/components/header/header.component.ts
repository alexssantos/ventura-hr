import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionManagerService } from 'src/app/core/services/session-mng.service';
import { SignInUpService } from 'src/app/core/services/sign-in-up.service';

const urlFakePhoto = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80";

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	public onProfileDrop: boolean = false;
	public urlFakePhoto = urlFakePhoto;

	constructor(
		private router: Router,
		private signInUpService: SignInUpService,
		private sessionService: SessionManagerService
	) { }

	ngOnInit(): void {
	}

	public logout(): void {
		this.signInUpService.logout();
	}

	public openProfileMenu(): void {
		this.onProfileDrop = !this.onProfileDrop;
	}

	public closeProfileMenu(): void {
		this.onProfileDrop = false;
	}

	public print(method: string): void {
		console.log(method);
	}

	public goToHome(): void {
		this.router.navigate(['/home']);
	}

}
