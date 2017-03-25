import { Component, OnInit } from '@angular/core';
import { LoginService }  from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [ LoginService ]
})

export class LoginComponent {
	title:string;
	logins: any;
	username: string; password: string;
	constructor(private loginService: LoginService) { }

	ngOnInit(){
		this.title = this.loginService.getTitle();
	}
	
	getAllLogin(){		
	   this.loginService.getAll().subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	this.logins = result

	             },
	             error =>  {console.error("[ loginService.getAll ]: " + <any>error);}
	         );
	}

	getById(id){		
	   this.loginService.getById(id).subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	this.logins = result

	             },
	             error =>  {console.error("[ loginService.getById ]: " + <any>error);}
	         );
	}
}
