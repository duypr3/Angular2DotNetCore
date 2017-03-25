import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { OxygenComponent } from './home/oxygen/oxygen.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
	
	{ path: 'home',  component: OxygenComponent },
	{ path: '',   redirectTo: '/home', pathMatch: 'full' },
	{ path: '**', component: NotFoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }