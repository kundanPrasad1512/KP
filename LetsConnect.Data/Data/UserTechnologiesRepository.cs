using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Data.Data
{
    public class UserTechnologiesRepository : IUserTechnologiesRepository
    {
        LetsConnectDBContext _context;

        public UserTechnologiesRepository(LetsConnectDBContext context)
        {
            _context = context;
        }

        public IEnumerable<UserTechnologies> GetAllUserTechnologies()
        {
            return _context.UserTechnologies;
        }

        //public UserTechnologies GetUserTechnologiesByUserTechnologiesId(int id)
        //{
        //    return _context.UserTechnologies.FirstOrDefault(u => u.UserTechnologiesID == id);
        //}

        public void SaveUserTechnologiesDetails(ICollection<UserTechnologies> objUserTechnologies)
        {

            try
            {
                foreach (UserTechnologies objUserTechnology in objUserTechnologies)
                {
                    _context.UserTechnologies.Add(objUserTechnology);
                }
                
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateUserTechnologiesDetails(int id, UserTechnologies objUserTechnologie)
        {
            try
            {
                //UserTechnologies user = _context.UserTechnologies.Where(u => u.UserTechnologiesID == id).FirstOrDefault();
                //user.FirstName = objUserTechnologie.FirstName;
                //user.LastName = objUserTechnologie.LastName;
                //user.ModifiedOn = DateTime.Now;
                //user.Address = objUserTechnologie.Address;
                //user.Email = objUserTechnologie.Email;
                //user.Gender = objUserTechnologie.Gender;
                //user.IsActiveForJob = objUserTechnologie.IsActiveForJob;
                //user.PhoneNo = objUserTechnologie.PhoneNo;
                //user.Technology = objUserTechnologie.Technology;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public void DeleteUserTechnologiesDetails(int id)
        //{
        //    UserTechnologies user = _context.UserTechnologies.Where(u => u.UserTechnologiesID == id).FirstOrDefault();
        //    _context.UserTechnologies.Remove(user);
        //    _context.SaveChanges();
        //}
    }
}