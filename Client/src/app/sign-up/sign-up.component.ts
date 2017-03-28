import { Component, OnInit, Injectable } from '@angular/core';
import { User } from './user.model';
import { SignUpService } from './sign-up.service';

/*export class User1{
    username: string;
    password: string;
    confirmPassword: string;
    email: string;    
}*/

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
  providers: [ SignUpService ]
})

export class SignUpComponent implements OnInit {
    
  constructor(private signUpService: SignUpService) { }

  user = new User();
  
  ngOnInit() {
      //console.log('INIT >>user>> ', this.user);    
  }

  createAccount(){
    console.log('createACcout>> ');
      this.signUpService.createAccount(this.user).subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	//this.logins = result

	             },
	             error =>  {console.error("[ loginService.getAll ]: " + <any>error);}
	         );
      /*this.alertService.success('Registration successful', true);
                    this.router.navigate(['/login']);*/
  }
  createWithParams(){
    let newparam : any = {
      param1: 123,
      param2: 'ajsodifjiosdf'
    }
    console.log('param day >> ', newparam);
    console.log('createWithParams>> ');
      this.signUpService.createWithParams(this.user, newparam).subscribe(
	             result => {
	             	console.log('reuslt>>> ', result); 
	             	//this.logins = result

	             },
	             error =>  {console.error("[ loginService.getAll ]: " + <any>error);}
	         );
  }
  changeRepassword(e){
    console.log('e>> ',e);
     console.log('user>> ', this.user);
     this.createWithParams();
  }
}
