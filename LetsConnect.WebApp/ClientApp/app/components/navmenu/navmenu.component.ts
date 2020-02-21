import { Component, OnInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { Http, RequestOptions, Headers, Response } from '@angular/http'; 
import { Observable } from 'rxjs/Rx'; 
import { Global } from '../../Shared/global';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Userervice } from '../../Service/user.service';
@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit{
    http: Http;
    name: any;
    thumbnail: string = require("../../../../wwwroot/images/avtar_man.jpg");
    formUpload: FormGroup;
    image: string;
    constructor(private route: Router, private fb: FormBuilder, private _Userervice: Userervice) {
        this.thumbnail = require("../../../../Documents/Images/Kundan Prasad.png");
        this.createForm();
    }

    createForm() {
        this.formUpload = this.fb.group({
            fileName: [''],
            fileContent:[''],
            fileID: 0
        });
    }

    ngOnInit(): void
    {
        //this.thumbnail = require('../../../../Documents/Images/Kundan Prasad.png');
        this.name = localStorage.getItem('name');  
        
    }

    Logout() {
        localStorage.removeItem('token');
        this.route.navigate(['login']);
    }
    
    onFileChange(event) {
        let reader = new FileReader();
        if (event.target.files && event.target.files.length > 0) {
            let file = event.target.files[0];
            reader.readAsDataURL(file);
            reader.onload = () => {
                this.formUpload = this.fb.group({
                    fileName: [file.name],
                    fileContent: reader.result.split(',')[1],
                    fileID:0
                });
                console.log(file);     
            };
        }
    }

    onSubmit() {
        debugger;
        const formModel = this.formUpload.value;
        //this.loading = true;       
        this._Userervice.post(Global.BASE_UPLOAD_PROFILE_IMAGE_ENDPOINT, formModel).subscribe(
            data => {
                if (data.token != undefined) //Success
                {
                    this.image = this.formUpload.value.fileName;
                }
                else {
                    //this.msg = "Please enter valid login credentials"
                }

            },
            error => {
                //this.msg = "Please enter valid login credentials"
            }
        );
        
    }

    clearFile() {
        //this.form.get('avatar').setValue(null);
        //this.fileInput.nativeElement.value = '';
    }
}
