using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Data.Data.Interfaces
{
    public interface ITechnologiesRepository
    {
        IEnumerable<Technologies> GetAllTechnologies();
        Technologies GetTechnologiesByTechnologiesId(int id);
        void SaveTechnologiesDetails(Technologies objTechnologies);
        void UpdateTechnologiesDetails(Technologies objTechnologies);
        void DeleteTechnologiesDetails(int id);
    }
}
