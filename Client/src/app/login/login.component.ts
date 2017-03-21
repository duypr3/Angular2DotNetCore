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
		this.username = 'adiofjasdf';
		this.password = 'hehe';
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

	getById(id){		
	   this.loginService.getById(id).subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	this.logins = result

	             },
	             error =>  {console.error("[ getById ]: " + <any>error);}
	         );
	}
}
