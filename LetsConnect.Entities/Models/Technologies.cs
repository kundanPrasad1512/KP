using LetsConnect.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LetsConnect.Models
{
    public class Technologies
    {
        [Key]
        public int TechnologyID { get; set; }
        public string TechnologyName { get; set; }
        
        public ICollection<UserTechnologies> UserTechnology { get; set; }
    }
}