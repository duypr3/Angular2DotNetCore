import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Config }  from './config';

@Injectable()

export class AppService {  
	private headers = new Headers({'Content-Type': 'application/json'});
  /*private options = new RequestOptions({ headers: this.headers });*/

  //private apiUrl = 'http://localhost:32760/api/login/AddOrUpdate';  // URL to web api
  apiUrl: string; controllerApi: string; actionApi: string;
  config: Config;
  constructor (private http: Http) {
    this.config = new Config();
  }
  
  setController(controllerName: string){
    if (typeof(controllerName) == 'undefined') controllerName = "";
    this.controllerApi = controllerName;
  }

  setAction(actionName: string){
    if (typeof(actionName) == 'undefined') actionName = "";
    this.actionApi = actionName;
  }

  buildApiUrl(){
    this.apiUrl = this.config.domainApi  + "/" + this.config.serviceBase + "/" + this.controllerApi + "/" + this.actionApi;
    //this.apiUrl = "http://localhost:32760"  + "/" + "api" + "/" + this.controllerApi + "/" + this.actionApi;
  }

  buildApiUrlWithActionName(controllerName: string, actionName: string){
    this.setController(controllerName);
    this.setAction(actionName);
    this.buildApiUrl();

    return this.apiUrl;
  }

  buildRequestOption(params?: any): RequestOptions{      
      let options = new RequestOptions({
        headers: this.headers
      });

      if (typeof(params) != 'undefined'){       
          let paramsURLSearch = new URLSearchParams();
          for(let key in params) {
              paramsURLSearch.set(key, params[key]);
          }
          options.search = paramsURLSearch;      
      }
      console.log("RequestOptions>>>> ",options);
      return options;
  }

  //------------- Build method -------------//
  get(actionName: string, params?: any): Observable<any>{    
    this.setAction(actionName);
    this.buildApiUrl();
    return this.http.get(this.apiUrl, this.buildRequestOption(params))
                    .map(this.extractData)
                    .catch(this.handleError);

  }

  addOrUpdate(actionName: string, data: any, params?: any){
    this.setAction(actionName);
    this.buildApiUrl();
    //console.log('api>> ', this.apiUrl);
     console.log("parasm>>> ", this.buildRequestOption(params));
    let body = JSON.stringify(data);
    return this.http.post(this.apiUrl, body, this.buildRequestOption(params))
                    .map(this.extractData)
                    .catch(this.handleError);
  }
  
  delete(actionName: string, params?: any){    
    this.setAction(actionName);
    this.buildApiUrl();
    //let body = JSON.stringify(data);
    return this.http.post(this.apiUrl, {}, this.buildRequestOption(params))
                    .map(this.extractData)
                    .catch(this.handleError);
  }
  //------------ END BUILD METHOD ---------------//

  
  private extractData(res: Response) {
    //console.log('res>> ', res);
    let body = res.json();
    //console.log('body>> ',body);
    return body || { };
  }

  private handleError (error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}