import { Component, OnInit, ViewChild } from '@angular/core';
import { TechnologiesService } from '../../Service/technologies.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { ITechnology } from '../../model/itechnology';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';

@Component({
    templateUrl: './technologies.component.html'
})

export class TechnologiesComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;
    technologies: ITechnology[];
    technologie: ITechnology;
    msg: string;
    indLoading: boolean = false;
    technologyForm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _technologiesService: TechnologiesService) { }

    ngOnInit(): void {
        this.technologyForm = this.fb.group({
            technologyID: ['0'],
            technologyName: [''],
            user:['']
        });
        this.LoadTechnologies();
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

    addTechnology() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Technology";
        this.modalBtnTitle = "Add";
        this.technologyForm.reset();
        this.technologyForm = this.fb.group({
            technologyID: [0],
            technologyName: [''],
            user: ['']
        });
        this.modal.open();
    }

    editTechnology(TechnologyID: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Technology";
        this.modalBtnTitle = "Update";
        this.technologie = this.technologies.filter(x => x.technologyID == TechnologyID)[0];
        this.technologyForm.setValue(this.technologie);
        this.modal.open();
    }

    deleteTechnology(TechnologyID: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.technologie = this.technologies.filter(x => x.technologyID == TechnologyID)[0];
        this.technologyForm.setValue(this.technologie);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
        switch (this.dbops) {
            case DBOperation.create:
                this._technologiesService.post(Global.BASE_TECHNOLOGY_ENDPOINT + '/SaveTechnologiesDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadTechnologies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadTechnologies();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._technologiesService.put(Global.BASE_TECHNOLOGY_ENDPOINT + '/UpdateTechnologiesDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.LoadTechnologies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadTechnologies();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                console.log(formData.value);
                this._technologiesService.delete(Global.BASE_TECHNOLOGY_ENDPOINT + '/DeleteTechnologiesDetails?id=', formData.value.technologyID).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.LoadTechnologies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadTechnologies();
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
        isEnable ? this.technologyForm.enable() : this.technologyForm.disable();
    }
}