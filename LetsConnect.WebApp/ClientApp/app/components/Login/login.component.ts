import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NavMenuComponent } from '../navmenu/navmenu.component';
import { LoginService } from '../../Service/login.service';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';
import { ILogin } from '../../model/ilogin';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { URLSearchParams } from "@angular/http";

@Component({ 
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    login: ILogin;
    loginForm: FormGroup;
    msg: string = "";
    username: string = "";
    password: string = "";

    constructor(private route: Router, private fb: FormBuilder, private _loginService: LoginService) { }

    ngOnInit(): void {
        this.loginForm = this.fb.group({
            userName: [''],
            password: ['']
        });
        
    }
    Authenticate(formData: any) {

        this._loginService.post(Global.BASE_LOGIN_ENDPOINT, formData._value).subscribe(
            data => {               
                if (data.token != undefined) //Success
                {
                    
                    localStorage.setItem('name', data.name);
                    localStorage.setItem('token', data.token);
                    console.log(data.token);
                    this.route.navigate(['navmenu']);
                }
                else {
                    this.msg = "Please enter valid login credentials"
                }
                
            },
            error => {
                this.msg = "Please enter valid login credentials"
            }
        );
        
    }


}
