import { Injectable, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class HomeService {

    constructor(private _http: Http) { }

    get(url: string): Observable<any> {
        let authToken = "";// localStorage.getItem('token');
        let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'bearer ' + authToken });
        console.log(headers);
        let options = new RequestOptions({ headers: headers });
        return this._http.get(url, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    post(url: string, model: any): Observable<any> {
        let authToken = localStorage.getItem('token');
        let body = JSON.stringify(model);
        let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'bearer ' + authToken });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(url, body, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    put(url: string, id: number, model: any): Observable<any> {
        let body = JSON.stringify(model);
        let authToken = localStorage.getItem('token');
        let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'bearer ' + authToken });
        let options = new RequestOptions({ headers: headers });
        return this._http.put(url + id, body, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    delete(url: string, id: number): Observable<any> {
        let authToken = localStorage.getItem('token');
        let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'bearer ' + authToken });
        let options = new RequestOptions({ headers: headers });
        return this._http.delete(url + id, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}