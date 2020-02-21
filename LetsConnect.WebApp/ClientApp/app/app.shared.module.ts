import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';

import { EmployeeComponent } from './components/User/employee.component';
import { RoleComponent } from './components/Roles/roles.component';
import { LoginComponent } from './components/Login/login.component';
import { TechnologiesComponent } from './components/Technologies/technologies.component';
import { ExperienceComponent } from './components/Experience/experience.component';
import { MessageComponent } from './components/messages/message.component';
import { SocialWallComponent } from './components/socialWall/social-wall.component';

import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import { AuthGuardService } from './Service/Authentication/auth-guard.service';
import { AuthService } from './Service/Authentication/auth.service'
import { LoginService } from './Service/login.service';
import { Userervice } from './Service/user.service';
import { RoleService } from './Service/role.service';
import { TechnologiesService } from './Service/technologies.service';
import { ExperienceService } from './Service/experience.service';
import { HomeService } from './Service/home.service';
import { HubConnection } from '@aspnet/signalr';

import { Angular2SocialLoginModule } from "angular2-social-login";


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        LoginComponent,
        RoleComponent,
        TechnologiesComponent,
        ExperienceComponent,
        EmployeeComponent,
        MessageComponent,
        SocialWallComponent
    ],
    providers: [       
         Userervice
        , RoleService
        , TechnologiesService
        , ExperienceService
        , LoginService
        , AuthGuardService
        , AuthService
        , HomeService
        
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        Ng2Bs3ModalModule,
        Angular2SocialLoginModule,
        RouterModule.forRoot([
            { path: 'login', component: LoginComponent },
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            {
                path: '', component: NavMenuComponent,
                children: [
                    { path: '', component: HomeComponent },
                    { path: 'User', component: EmployeeComponent, canActivate: [AuthGuardService] },
                    { path: 'role', component: RoleComponent, canActivate: [AuthGuardService] },
                    { path: 'technologies', component: TechnologiesComponent, canActivate: [AuthGuardService] },
                    { path: 'experience', component: ExperienceComponent, canActivate: [AuthGuardService] },
                    { path: 'home', component: HomeComponent, canActivate: [AuthGuardService] },
                    { path: 'message', component: MessageComponent, canActivate: [AuthGuardService] },
                    { path: 'social-wall', component: SocialWallComponent, canActivate: [AuthGuardService] }
                ]
            },
            { path: '**', redirectTo: 'home' }  
        ])
    ]
})
export class AppModuleShared {
}

//let providers = {
//    "google": {
//        "clientId": "GOOGLE_CLIENT_ID"
//    },
//    "linkedin": {
//        "clientId": "LINKEDIN_CLIENT_ID"
//    },
//    "facebook": {
//        "clientId": "FACEBOOK_CLIENT_ID",
//        "apiVersion": "<version>" //like v2.4
//    }
//};
//Angular2SocialLoginModule.loadProvidersScripts(providers);
