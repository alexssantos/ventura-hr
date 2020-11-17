import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatChipInputEvent } from '@angular/material/chips';

@Component({
	selector: 'search-home',
	templateUrl: './search-home.component.html',
	styleUrls: ['./search-home.component.scss']
})
export class SearchHomeComponent implements OnInit {

	visible = true;
	selectable = true;
	removable = true;
	addOnBlur = true;
	
	@Output('searchChanges') searchChanges = new EventEmitter<string[]>();

	constructor() { }

	ngOnInit(): void {
	}
	
	readonly separatorKeysCodes: number[] = [ENTER, COMMA];
	keywords: string[] = [];

	add(event: MatChipInputEvent): void {
		const input = event.input;
		const value = event.value.toLowerCase();
		const oldKeyWords = Object.assign([], this.keywords);
		
		let include = this.keywords.includes(value);
		if ((value || '').trim() && !include) {
			this.keywords.push(value.trim());
		}

		// Reset the input value
		if (input) {
			input.value = '';
		}
		
		let equalList = this.compareList(oldKeyWords, this.keywords);
		if (!equalList) {
			this.searchChanges.emit(this.keywords);			
		}
	}

	remove(keyword: string): void {
		const index = this.keywords.indexOf(keyword);

		if (index >= 0) {
			this.keywords.splice(index, 1);
		}
		this.searchChanges.emit(this.keywords);
	}

	public compareList(a: string[], b: string[]): boolean{
		return a.sort().toString() == b.sort().toString() 
	}
}
