import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';

import { AppService }  from '../app.service';

@Injectable()

export class LoginService extends AppService {

	constructor (private _http: Http) {		
		super(_http);

		this.setController("Login");
	}

	result: any;
	errorMessage: string;

	getById(id: number): any{
		this.get("GetById?id=" + id);			
	}

	getAll(): any{
		return this.get("GetAll");
	}

	getTitle() {
        return 'LOGIN DEY!';
    }
}