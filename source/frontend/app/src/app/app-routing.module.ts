import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { SignInUpComponent } from './pages/sign-in-up/sign-in-up.component';
import { VacancyDetailComponent } from './pages/vacancy-detail/vacancy-detail.component';

const routes: Routes = [
	{ path: 'access', component: SignInUpComponent },
	{ path: 'home', component: HomeComponent },
	{ path: 'vacancy/:id', component: VacancyDetailComponent},
	{
		path: 'profile', redirectTo: 'compare', pathMatch: 'full'
	},	
	{
		path: '', redirectTo: '/home', pathMatch: 'full'
	},	
	{
		//entra NotFoundCOmponent
		path: '**', redirectTo: "/home"
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
