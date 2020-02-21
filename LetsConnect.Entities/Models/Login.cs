using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsConnect.Entities.Models
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        public string UserName { get; set; }        
        public DateTime LoggedIn { get; set; }
        public DateTime LoggedOut { get; set; }
        public string Password { get; set; }        
    }
}
