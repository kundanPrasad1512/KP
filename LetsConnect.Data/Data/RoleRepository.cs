using LetsConnect.Data.Data.Interfaces;
using LetsConnect.DBContext;
using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Data.Data
{
    public class RoleRepository: IRoleRepository
    {
        LetsConnectDBContext _context;

        public RoleRepository(LetsConnectDBContext context)
        {
            _context = context;
        }

        public IQueryable<Role> GetAllRole()
        {
            return _context.Role;
        }

        public Role GetRoleByRoleId(int id)
        {
            return _context.Role.FirstOrDefault(u => u.RoleID == id);
        }

        public void SaveRoleDetails(Role objRole)
        {

            try
            {
                _context.Role.Add(objRole);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateRoleDetails(Role objRole)
        {
            try
            {
                Role role = new Role();
                role = _context.Role.Where(u => u.RoleID == objRole.RoleID).FirstOrDefault();
                role.RoleName = objRole.RoleName;              
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteRoleDetails(int id)
        {
            Role Role = _context.Role.Where(u => u.RoleID == id).FirstOrDefault();
            _context.Role.Remove(Role);
            _context.SaveChanges();
        }
    }
}