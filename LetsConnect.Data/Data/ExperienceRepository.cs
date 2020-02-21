using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Data.Data
{
    public class ExperienceRepository: IExperienceRepository
    {
        LetsConnectDBContext _context;

        public ExperienceRepository(LetsConnectDBContext context)
        {
            _context = context;
        }

        public IQueryable<Experience> GetAllExperience()
        {
            return _context.Experience;
        }

        public Experience GetExperienceByExperienceId(int id)
        {
            return _context.Experience.FirstOrDefault(u => u.ExperienceID == id);
        }

        public void SaveExperienceDetails(Experience objExperience)
        {

            try
            {
                if(objExperience != null)
                {
                    _context.Experience.Add(objExperience);
                    _context.SaveChanges();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateExperienceDetails(Experience objExperience)
        {
            try
            {
                Experience Experience = _context.Experience.Where(u => u.ExperienceID == objExperience.ExperienceID).FirstOrDefault();
                Experience.ExperienceRange = objExperience.ExperienceRange;
                
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteExperienceDetails(int id)
        {
            Experience Experience = _context.Experience.Where(u => u.ExperienceID == id).FirstOrDefault();
            _context.Experience.Remove(Experience);
            _context.SaveChanges();
        }

    }
}