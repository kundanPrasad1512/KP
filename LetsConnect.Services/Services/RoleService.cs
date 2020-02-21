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
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public void DeleteRoleDetails(int id)
        {
            _roleRepository.DeleteRoleDetails(id);
        }

        public IQueryable<Role> GetAllRole()
        {
            return _roleRepository.GetAllRole();
        }

        public Role GetRoleByRoleId(int id)
        {
            return _roleRepository.GetRoleByRoleId(id);
        }

        public void SaveRoleDetails(Role objRole)
        {
            _roleRepository.SaveRoleDetails(objRole);
        }

        public void UpdateRoleDetails(Role objRole)
        {
            _roleRepository.UpdateRoleDetails(objRole);
        }
    }
}