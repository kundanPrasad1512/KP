using LetsConnect.Data.Data;
using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Entities.Models;
using LetsConnect.Models;
using LetsConnect.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Service.Services
{
    public class UserTechnologiesServices : IUserTechnologiesServices
    {
        IUserTechnologiesRepository userTechnologiesRepository;
        LetsConnectDBContext context;
        public UserTechnologiesServices()
        {
            userTechnologiesRepository = new UserTechnologiesRepository(context);
        }

        //public void DeleteUserTechnologiesDetails(int id)
        //{
        //    userTechnologiesRepository.DeleteUserTechnologiesDetails(id);
        //}

        public IEnumerable<UserTechnologies> GetAllUserTechnologies()
        {
            return userTechnologiesRepository.GetAllUserTechnologies();
        }

        //public UserTechnologies GetUserTechnologiesByUserTechnologiesId(int id)
        //{
        //    return userTechnologiesRepository.GetUserTechnologiesByUserTechnologiesId(id);
        //}

        public void SaveUserTechnologiesDetails(ICollection<UserTechnologies> objUserTechnologies)
        {
            userTechnologiesRepository.SaveUserTechnologiesDetails(objUserTechnologies);
        }

        public void UpdateUserTechnologiesDetails(int id, UserTechnologies objUserTechnologies)
        {
            userTechnologiesRepository.UpdateUserTechnologiesDetails(id, objUserTechnologies);
        }
    }
}