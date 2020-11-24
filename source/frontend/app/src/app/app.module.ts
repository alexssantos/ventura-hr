import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { SignInUpComponent } from './pages/sign-in-up/sign-in-up.component';
import { HeaderComponent } from './theme/components/header/header.component';
import { FilterBoxComponent } from './theme/components/filter-box/filter-box.component';
import { SearchBarComponent } from './theme/components/search-bar/search-bar.component';
import { JobCardComponent } from './theme/components/job-card/job-card.component';
import { SignInUpService } from './core/services/sign-in-up.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { MaterialModule } from './material/material.module';
import { ModalCreateVacancy } from './theme/components/modal-create-vacancy/modal-create-vacancy.component';
import { TokenInterceptorService } from './core/services/token-interceptor.service';
import { CommonModule } from '@angular/common';
import { SearchHomeComponent } from './theme/components/search-home/search-home.component';
import { VacancyDetailComponent } from './pages/vacancy-detail/vacancy-detail.component';
import { ModalApplyVacancy } from './theme/components/modal-apply-vacancy/modal-apply-vacancy.component';



@NgModule({
	declarations: [
		AppComponent,
		HomeComponent,
		SignInUpComponent,
		HeaderComponent,
		FilterBoxComponent,
		SearchBarComponent,
		JobCardComponent,
		ModalCreateVacancy,
		SearchHomeComponent,
		VacancyDetailComponent,
		ModalApplyVacancy
	],
	imports: [
		BrowserModule,		
		CommonModule,
		BrowserAnimationsModule,
		AppRoutingModule, 
		FormsModule,		
		ReactiveFormsModule,
		MaterialModule,
		//WARNING:  import HttpClientModule after BrowserModule.
		HttpClientModule,
		ToastrModule.forRoot({  
			timeOut: 4000,
			positionClass:'toast-bottom-right',  
			closeButton: true,  			  
		}), // ToastrModule added
	],
	providers: [
		SignInUpService,
		{provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true}
	],
	entryComponents: [
		ModalCreateVacancy,
		ModalApplyVacancy	
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
