import { Component, OnInit, ViewChild } from '@angular/core';
import { Userervice } from '../../Service/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IUser } from '../../Model/user';
import { IRole } from '../../Model/irole';
import { ITechnology } from '../../Model/ITechnology';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';
import { RoleService } from '../../Service/role.service'
import { ExperienceService } from '../../Service/experience.service'
import { TechnologiesService } from '../../Service/technologies.service'
import { ExperienceComponent } from '../../components/Experience/experience.component';
import { IExperience } from '../../Model/IExperience';

@Component({
    templateUrl: './employee.component.html'
})

export class EmployeeComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;
    User: IUser[];
    user: IUser;
    roles: IRole[];
    technologies: ITechnology[]
    experiences: IExperience[]
    msg: string;
    indLoading: boolean = false;
    userFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder
        , private _Userervice: Userervice
        , private _rolesService: RoleService
        , private _technologiesService: TechnologiesService
        , private _experienceService: ExperienceService
    ) { }

    ngOnInit(): void {
        this.userFrm = this.fb.group({
            userID: [''],
            firstName: [''],
            lastName: [''],
            phoneNo: [''],
            email: [''],
            createdOn: [''],
            modifiedOn: [''],
            password: [''],
            address: [''],
            gender: [''],
            IsActive: [''],
            IsActiveForJob: [''],
            IsDeleted: [''],
            roleID: [''],
            roles: [''],
            technology: this.fb.array([this.createItem()]),
            experience: [''],
            experienceID: ['']
        });
        this.LoadUser();
        this.LoadRoles();
        this.LoadTechnologies();
        this.LoadExperience();
    }

    LoadUser(): void {
        this.indLoading = true;
        this._Userervice.get(Global.BASE_USER_ENDPOINT + '/GetAllUser')
            .subscribe(User => {
                this.User = User;
                this.indLoading = false;
            },
            error => this.msg = <any>error);
        
    }

    addUser() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New User";
        this.modalBtnTitle = "Add";
        this.userFrm.reset();
        this.userFrm = this.fb.group({
            userID: [0],
            firstName: [''],
            lastName: [''],
            phoneNo: [''],
            email: [''],
            createdOn: ['2018-07-06T21:55:41.543'],
            modifiedOn: ['2018-07-06T21:55:41.543'],
            password: [''],
            address: [''],
            gender: [''],
            IsActive: [true],
            IsActiveForJob: [false],
            IsDeleted: [false],
            roleID: [''],
            roles: [''],
            technology: this.fb.array([this.createItem()]),
            experience: [''],
            experienceID: ['']
        });
        this.modal.open();
    }

    createItem(): FormGroup {
        return this.fb.group({
            technologyID: 1,
            userID: 0
        });
    }

    editUser(UserID: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit User";
        this.modalBtnTitle = "Update";
        this.user = this.User.filter(x => x.UserID == UserID)[0];
        console.log(this.user);
        console.log(this.userFrm);
        this.userFrm.setValue(this.user);
        
        this.modal.open();
    }

    LoadExperience(): void {
        this.indLoading = true;
        this._experienceService.get(Global.BASE_EXPERIENCE_ENDPOINT + '/GetAllExperience')
            .subscribe(experiences => {
                this.experiences = experiences;
                this.indLoading = false;
            },
            error => this.msg = <any>error);

    }

    LoadRoles(): void {
        this.indLoading = true;
        this._rolesService.get(Global.BASE_ROLE_ENDPOINT + '/GetAllRole')
            .subscribe(roles => {
                this.roles = roles;
                console.log(roles);
                this.indLoading = false;
            },
            error => this.msg = <any>error);

    }

    LoadTechnologies(): void {
        this.indLoading = true;
        this._technologiesService.get(Global.BASE_TECHNOLOGY_ENDPOINT + '/GetAllTechnologies')
            .subscribe(technologies => {
                this.technologies = technologies;
                this.indLoading = false;
            },
            error => this.msg = <any>error);

    }

    deleteUser(id: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.user = this.User.filter(x => x.UserID == id)[0];
        this.userFrm.setValue(this.user);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
        console.log(formData.value);
        switch (this.dbops) {
            case DBOperation.create:
                this._Userervice.post(Global.BASE_USER_ENDPOINT +'/SaveUserDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadUser();
                        }
                        else
                        {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadUser();
                        this.modal.dismiss();
                    },
                    error => {
                      this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._Userervice.put(Global.BASE_USER_ENDPOINT +'/UpdateUserDetails?id=', formData.value.UserID, formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.LoadUser();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadUser();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._Userervice.delete(Global.BASE_USER_ENDPOINT +'/DeleteUserDetails?id=', formData.value.UserID).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.LoadUser();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadUser();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

        }
    }

    SetControlsState(isEnable: boolean)
    {
        isEnable ? this.userFrm.enable() : this.userFrm.disable();
    }
}