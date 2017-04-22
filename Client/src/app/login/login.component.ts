import { Component, OnInit } from '@angular/core';
import { LoginService }  from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [ LoginService ]
})


export class LoginComponent  implements OnInit {
	constructor(private loginService: LoginService) { }
	user: any = {};
	
	users: any[] = [
		{email: "admin", password: "admin@123456"},
		{email: "duy", password: "duy@123456"}
	]

	ngOnInit(){			
		console.log("user>> ", this.users);
		// if (this.checkCert()){
		// 	this.user = localStorage.getItem("user");
		// }
		// this.users = [
		// 	new Login('admin','admin@123456'),
		// 	new Login('duy','duy@123456')
		// ];
	}
	login(){
		console.log("userCurrent>> ", this.user);
		let userAuth = this.users.find(u => u.email === this.user.email);
		if (userAuth && userAuth.password === this.user.password){
			sessionStorage.setItem("user",userAuth);
			console.log('local>> ', sessionStorage.getItem("user"));
		}
		//sessionStorage.removeItem("user");
		console.log('checkUser>> ', userAuth);		
	}
	checkCert(){
		if (sessionStorage.getItem("user") === null){
			return false;
		}
		else return true;
	}
	getAllLogin(){	

			//console.log('users>>> ',this.users);
	//    this.loginService.getAll().subscribe(
	//              result => {
	//              	console.log('reuslt>>> ', result);
	//              },
	//              error =>  {console.error("[ loginService.getAll ]: " + <any>error);}
	//          );
	}

	getById(id){		
	   this.loginService.getById(id).subscribe(
	             result => {
	             	console.log('reuslt>>> ', result);
	             },
	             error =>  {console.error("[ loginService.getById ]: " + <any>error);}
	         );
	}
}
