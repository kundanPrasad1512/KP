import { Component, OnInit, ViewChild } from '@angular/core';
import { ExperienceService } from '../../Service/experience.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IExperience } from '../../model/IExperience';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';

@Component({
    templateUrl: './experience.component.html'
})

export class ExperienceComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;

    experiences: IExperience[];
    experience: IExperience;
    msg: string;
    indLoading: boolean = false;
    experienceForm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _experienceService: ExperienceService) { }

    ngOnInit(): void {
        this.experienceForm = this.fb.group({
            experienceID: [''],
            experienceRange: [''],
            user: ['']
        });
        this.LoadExperiences();
    }

    LoadExperiences(): void {
        this.indLoading = true;
        this._experienceService.get(Global.BASE_EXPERIENCE_ENDPOINT + '/GetAllExperience')
            .subscribe(experiences => {
                this.experiences = experiences;
                this.indLoading = false;
            },
            error => this.msg = <any>error);

    }

    addExperience() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Experience";
        this.modalBtnTitle = "Add";
        this.experienceForm.reset();
        this.experienceForm = this.fb.group({
            experienceID: [0],
            experienceRange: [''],
            user: ['']
        });
        this.modal.open();
    }

    editExperience(ExperienceID: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Experience";
        this.modalBtnTitle = "Update";
        this.experience = this.experiences.filter(x => x.experienceID == ExperienceID)[0];
        this.experienceForm.setValue(this.experience);
        this.modal.open();
    }

    deleteExperience(ExperienceID: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.experience = this.experiences.filter(x => x.experienceID == ExperienceID)[0];
        this.experienceForm.setValue(this.experience);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
        switch (this.dbops) {
            case DBOperation.create:
                this._experienceService.post(Global.BASE_EXPERIENCE_ENDPOINT + '/SaveExperienceDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadExperiences();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadExperiences();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._experienceService.put(Global.BASE_EXPERIENCE_ENDPOINT + '/UpdateExperienceDetails', formData.value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.LoadExperiences();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadExperiences();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._experienceService.delete(Global.BASE_EXPERIENCE_ENDPOINT + '/DeleteExperienceDetails?id=', formData.value.experienceID).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.LoadExperiences();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.LoadExperiences();
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
        isEnable ? this.experienceForm.enable() : this.experienceForm.disable();
    }
}