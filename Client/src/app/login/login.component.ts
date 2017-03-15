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
	constructor(private loginService: LoginService) { }

	ngOnInit(){
		this.title = this.loginService.getTitle();
	//	this.logins = this.loginService.getAll();
	}
	
	getAllLogin(){		
	   this.loginService.getAll().subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	this.logins = result

	             },
	             error =>  {console.error("[ GetAll ]: " + <any>error);}
	         );
	}
}
