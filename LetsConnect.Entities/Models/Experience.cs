using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LetsConnect.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        public string ExperienceRange { get; set; }

        public ICollection<User> User { get; set; }
    }
}