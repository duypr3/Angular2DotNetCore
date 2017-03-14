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
	constructor(private loginService: LoginService) { }

	ngOnInit(){
		this.title = this.loginService.someMethod();
	}
	// getAllLogin(){		
	//     this.loginService.get("login","GetAll")
	//       	.subscribe(
 //                     result => this.logins = result,
 //                     error =>  this.errorMessage = <any>error);
	// }
}
