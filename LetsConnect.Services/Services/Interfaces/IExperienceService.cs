using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Service.Services.Interfaces
{
    public interface IExperienceService
    {
        IQueryable<Experience> GetAllExperience();
        Experience GetExperienceByExperienceId(int id);
        void SaveExperienceDetails(Experience objUser);
        void UpdateExperienceDetails(Experience objUser);
        void DeleteExperienceDetails(int id);
    }
}
