using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Data.Data.Interfaces
{
    public interface IExperienceRepository
    {
        IQueryable<Experience> GetAllExperience();
        Experience GetExperienceByExperienceId(int id);
        void SaveExperienceDetails(Experience objUser);
        void UpdateExperienceDetails(Experience objUser);
        void DeleteExperienceDetails(int id);
    }
}
