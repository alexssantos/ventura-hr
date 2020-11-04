import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from "@angular/material/menu";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';


const modulesList = [
	MatToolbarModule,
	MatButtonModule,
	MatIconModule,
	MatMenuModule,
	MatCardModule,
	MatInputModule,
	MatDatepickerModule,
	MatNativeDateModule,
	MatRadioModule
];

@NgModule({
	imports: modulesList,
	exports: modulesList,
})
export class MaterialModule { }