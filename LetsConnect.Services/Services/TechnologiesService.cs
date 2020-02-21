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
    public class TechnologiesService : ITechnologiesService
    {
        ITechnologiesRepository _technologiesRepository;
        
        public TechnologiesService(ITechnologiesRepository technologiesRepository)
        {
            this._technologiesRepository = technologiesRepository;
        }

        public void DeleteTechnologiesDetails(int id)
        {
            _technologiesRepository.DeleteTechnologiesDetails(id);
        }

        public IEnumerable<Technologies> GetAllTechnologies()
        {
            return _technologiesRepository.GetAllTechnologies();
        }

        public Technologies GetTechnologiesByTechnologiesId(int id)
        {
            return _technologiesRepository.GetTechnologiesByTechnologiesId(id);
        }

        public void SaveTechnologiesDetails(Technologies objTechnologies)
        {
            _technologiesRepository.SaveTechnologiesDetails(objTechnologies);
        }

        public void UpdateTechnologiesDetails(Technologies objTechnologies)
        {
            _technologiesRepository.UpdateTechnologiesDetails(objTechnologies);
        }
    }
}