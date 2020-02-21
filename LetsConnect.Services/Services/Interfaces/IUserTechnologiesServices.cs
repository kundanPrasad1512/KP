using LetsConnect.Entities.Models;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Service.Services.Interfaces
{
    public interface IUserTechnologiesServices
    {
        IEnumerable<UserTechnologies> GetAllUserTechnologies();
        //UserTechnologies GetUserTechnologiesByUserTechnologiesId(int id);
        void SaveUserTechnologiesDetails(ICollection<UserTechnologies> objUserTechnologies);
        void UpdateUserTechnologiesDetails(int id, UserTechnologies objUserTechnologies);
        //void DeleteUserTechnologiesDetails(int id);
       
    }
}
