import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';

import { AppService }  from '../app.service';
import { Config }  from '../config';

@Injectable()

export class LoginService extends AppService {

	constructor () {
		let http : Http;
		let config: Config;
		super(http, config);
	}

	// getAllLogin(){		
	//     this.dataService.get("login","GetAll")
	//       	.subscribe(
 //                     result => this.logins = result,
 //                     error =>  this.errorMessage = <any>error);
	// }
	someMethod() {
        return 'Hey!';
    }
}