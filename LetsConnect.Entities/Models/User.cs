using LetsConnect.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LetsConnect.Models
{
    
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Password { get; set; }
        public string  Address { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveForJob { get; set; }
        public bool IsDeleted { get; set; }

        public int ExperienceID { get; set; }
        public Experience Experience { get; set; }

        public int RoleID { get; set; }
        public Role Roles { get; set; }

        public ICollection<UserTechnologies> UserTechnology { get; set; }
        
    }
}