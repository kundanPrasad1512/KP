using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Data.Data
{
    public class TechnologiesRepository: ITechnologiesRepository
    {
        LetsConnectDBContext _context;

        public TechnologiesRepository(LetsConnectDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Technologies> GetAllTechnologies()
        {
            return _context.Technologies;
        }

        public Technologies GetTechnologiesByTechnologiesId(int id)
        {
            return _context.Technologies.FirstOrDefault(u => u.TechnologyID == id);
        }

        public void SaveTechnologiesDetails(Technologies objTechnologies)
        {

            try
            {
                _context.Technologies.Add(objTechnologies);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateTechnologiesDetails(Technologies objTechnologies)
        {
            try
            {
                Technologies Technologies = _context.Technologies.Where(u => u.TechnologyID == objTechnologies.TechnologyID).FirstOrDefault();
                Technologies.TechnologyName = objTechnologies.TechnologyName;               
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteTechnologiesDetails(int id)
        {
            Technologies Technologies = _context.Technologies.Where(u => u.TechnologyID == id).FirstOrDefault();
            _context.Technologies.Remove(Technologies);
            _context.SaveChanges();
        }
    }
}