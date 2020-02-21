export interface IUser {   
    UserID: number,
    FirstName :string,
    LastName: string,
    PhoneNo: string,
    Email: string,
    CreatedOn: Date,
    ModifiedOn: Date,
    Password: string,
    Address: string,
    Gender: number,
    IsActive: boolean,
    IsActiveForJob: boolean,
    IsDeleted: boolean,
    RoleID: number,
    Roles:string,
    Technology: any[],
    Experience: string,
    ExperienceID: number

}