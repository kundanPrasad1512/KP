import { Component, OnInit, ViewChild } from '@angular/core';
import { RoleService } from '../../Service/role.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IRole } from '../../model/irole';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';
import { Router } from '@angular/router';

@Component({
    templateUrl: './roles.component.html?v=1.1'
})

export class RoleComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;
    roles: IRole[];
    role: IRole;
    msg: string;
    indLoading: boolean = false;
    roleForm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private route: Router,private fb: FormBuilder, private _roleService: RoleService) { }

    ngOnInit(): void {
        this.roleForm = this.fb.group({
            roleID: [''],
            roleName: [''],
            user: ['']            
        });
        this.LoadRoles();
    }

    LoadRoles(): void {
        this.indLoading = true;
        this._roleService.get(Global.BASE_ROLE_ENDPOINT + '/GetAllRole')
            .subscribe(roles => {
                console.log(roles)
                this.roles = roles;
                this.indLoading = false;
            },
            error => this.msg = <any>error);

    }

    addRole() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Role";
        this.modalBtnTitle = "Add";
        this.roleForm.reset();
        this.roleForm = this.fb.group({
            roleID: [0],
            roleName: [''],
            user: ['']
        });
        this.modal.open();
    }

    editRole(RoleID: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Role";
        this.modalBtnTitle = "Update";
        //console.log(this.roles);
        this.role = this.roles.filter(x => x.roleID == RoleID)[0];
        this.roleForm.setValue(this.role);
        this.modal.open();
    }

    deleteRole(RoleID: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.role = this.roles.filter(x => x.roleID == RoleID)[0];
        this.roleForm.setValue(this.role);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
        switch (this.dbops) {
            case DBOperation.create:
                this._roleService.post(Global.BASE_ROLE_ENDPOINT + '/SaveRoleDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadRoles();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadRoles();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._roleService.put(Global.BASE_ROLE_ENDPOINT + '/UpdateRoleDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.LoadRoles();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadRoles();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._roleService.delete(Global.BASE_ROLE_ENDPOINT + '/DeleteRoleDetails/', formData.value.roleID).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.LoadRoles();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadRoles();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
        }
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.roleForm.enable() : this.roleForm.disable();
    }
}