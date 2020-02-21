using LetsConnect.Data.Data;
using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Service.Services
{
    public class Userervice : IUserervice
    {
        IUserRepository _userRepository;
        LetsConnectDBContext context;
        public Userervice(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUserDetails(int id)
        {
            _userRepository.DeleteUserDetails(id);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserByUserId(int id)
        {
            return _userRepository.GetUserByUserId(id);
        }

        public void SaveUserDetails(User objUser)
        {
            _userRepository.SaveUserDetails(objUser);
        }

        public void UpdateUserDetails(User objUser)
        {
            _userRepository.UpdateUserDetails(objUser);
        }

        public User ValidateUser(string email, string password)
        {
            return _userRepository.ValidateUser(email, password);
        }
    }
}