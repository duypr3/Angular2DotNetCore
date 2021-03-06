import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';

import { AppService }  from '../app.service';

@Injectable()

export class SignUpService extends AppService {

	constructor (private _http: Http) {		
		super(_http);

		this.setController("Login");
	}

	createAccount(user: any): any{
		return this.addOrUpdate("CreateAccount",user);			
	}

	createWithParams(user: any, params: any){
		return this.addOrUpdate("CreateAccountWithParams", user, params);
	}

	deleteSignUp(params?: any){
		return this.delete("Delete", params);
	}

	getByInfo(params: any){
		return this.get("GetByInfo",params);
	}
	
	getAll(): any{
		return this.get("GetAll");
	}

	getTitle() {
        return 'LOGIN DEY!';
    }
}