import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';

import { EmployeeComponent } from './components/User/employee.component';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { RoleComponent } from './components/Roles/roles.component';
import { TechnologiesComponent } from './components/Technologies/technologies.component';
import { ExperienceComponent } from './components/Experience/experience.component';
import { LoginComponent } from './components/Login/login.component';
import { Userervice } from './Service/user.service';
import { RoleService } from './Service/role.service';
import { TechnologiesService } from './Service/technologies.service';
import { ExperienceService } from './Service/experience.service';
import { LoginService } from './Service/login.service'
import { AuthGuardService } from './Service/Authentication/auth-guard.service'
import { AuthService } from './Service/Authentication/auth.service'
//import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
//import { HubConnection } from '@aspnet/signalr';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared
        
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
        , Userervice
        , RoleService
        , TechnologiesService
        , ExperienceService
        , LoginService
        , AuthGuardService
        , AuthService
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
