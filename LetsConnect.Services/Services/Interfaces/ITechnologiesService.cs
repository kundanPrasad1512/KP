using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Service.Services.Interfaces
{
    public interface ITechnologiesService
    {
        IEnumerable<Technologies> GetAllTechnologies();
        Technologies GetTechnologiesByTechnologiesId(int id);
        void SaveTechnologiesDetails(Technologies objTechnologies);
        void UpdateTechnologiesDetails(Technologies objTechnologies);
        void DeleteTechnologiesDetails(int id);
    }
}