using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LetsConnect.Entities.Models
{
    public class UserTechnologies
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
       
        public int TechnologyID { get; set; }
        public virtual Technologies Technology { get; set; }        
    }
}