using LetsConnect.Data.Data;
using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using LetsConnect.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Service.Services
{
    public class ExperienceService : IExperienceService
    {
        IExperienceRepository _experienceRepository;
       
        public ExperienceService(IExperienceRepository experienceRepository)
        {
            this._experienceRepository = experienceRepository;
        }

        public void DeleteExperienceDetails(int id)
        {
            _experienceRepository.DeleteExperienceDetails(id);
        }

        public IQueryable<Experience> GetAllExperience()
        {
            return _experienceRepository.GetAllExperience();
        }

        public Experience GetExperienceByExperienceId(int id)
        {
            return _experienceRepository.GetExperienceByExperienceId(id);
        }

        public void SaveExperienceDetails(Experience objExperience)
        {
            _experienceRepository.SaveExperienceDetails(objExperience);
        }

        public void UpdateExperienceDetails(Experience objExperience)
        {
            _experienceRepository.UpdateExperienceDetails(objExperience);
        }
    }
}