using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Data.Data
{
    public class UserRepository:IUserRepository
    {
        LetsConnectDBContext _context;

        public UserRepository(LetsConnectDBContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.User;
        }
        
        public User GetUserByUserId(int id)
        {
            return _context.User.FirstOrDefault(u => u.UserID == id);
        }
        
        public void SaveUserDetails(User objUser)
        {

            try
            {

                if (objUser.UserTechnology != null)
                {
                    _context.UserTechnologies.AddRange(objUser.UserTechnology);
                    //foreach (var obj in objUser.UserTechnology)
                    //{
                    //    _context.UserTechnologies.AddRange(obj);
                    //}
                }
                _context.User.Add(objUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public void UpdateUserDetails(User objUser)
        {
            try
            {
                User user = _context.User.Where(u => u.UserID == objUser.UserID).FirstOrDefault();
                user.FirstName = objUser.FirstName;
                user.LastName = objUser.LastName;
                user.ModifiedOn = DateTime.Now;
                user.Address = objUser.Address;
                user.Email = objUser.Email;
                user.Gender = objUser.Gender;
                user.IsActiveForJob = objUser.IsActiveForJob;
                user.PhoneNo = objUser.PhoneNo;
                user.UserTechnology = objUser.UserTechnology;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public void DeleteUserDetails(int id)
        {
            User user = _context.User.Where(u => u.UserID == id).FirstOrDefault();
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User ValidateUser(string email, string password)
        {
            return _context.User.Where(u=>u.Email== email && u.Password== password).FirstOrDefault();
        }

    }
}