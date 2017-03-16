import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';

import { AppService }  from '../app.service';

@Injectable()

export class LoginService extends AppService {

	constructor (private _http: Http) {		
		super(_http);

		this.setController("Values");
	}

	getById(id: number): any{
		return this.get(id);			
	}

	getAll(): any{
		return this.get("");
	}

	getTitle() {
        return 'LOGIN DEY!';
    }
}