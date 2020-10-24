import { Component, OnInit } from '@angular/core';

const urlFakePhoto = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80";

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	public onProfileDrop: boolean = false;
	public urlFakePhoto = urlFakePhoto;

	constructor() { }

	ngOnInit(): void {
	}

	public openProfileMenu():void {
		this.onProfileDrop = !this.onProfileDrop;
	}

}
