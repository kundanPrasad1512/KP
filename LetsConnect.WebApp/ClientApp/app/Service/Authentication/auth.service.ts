import { Injectable } from '@angular/core';
@Injectable()
export class AuthService {

    constructor() { }

    public isAuthenticated(): boolean {

        const token = localStorage.getItem('token');
        if (token != undefined && token !="") {
            return true;
        }
        return false;
        //return true;
        
    }

}