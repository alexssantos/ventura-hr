import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { SignInUpComponent } from './pages/sign-in-up/sign-in-up.component';
import { HeaderComponent } from './theme/components/header/header.component';
import { FilterBoxComponent } from './theme/components/filter-box/filter-box.component';
import { SearchBarComponent } from './theme/components/search-bar/search-bar.component';
import { JobCardComponent } from './theme/components/job-card/job-card.component';

@NgModule({
	declarations: [
		AppComponent,
		HomeComponent,
		SignInUpComponent,
		HeaderComponent,
		FilterBoxComponent,
		SearchBarComponent,
		JobCardComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
