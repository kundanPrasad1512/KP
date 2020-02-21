using LetsConnect.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Data.Data.Interfaces
{
    public interface IUserTechnologiesRepository
    {
        IEnumerable<UserTechnologies> GetAllUserTechnologies();
        //UserTechnologies GetUserTechnologiesByUserTechnologiesId(int id);
        void SaveUserTechnologiesDetails(ICollection<UserTechnologies> objUserTechnologies);
        void UpdateUserTechnologiesDetails(int id, UserTechnologies objUserTechnologies);
        //void DeleteUserTechnologiesDetails(int id);
    }
}
