using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsConnect.Data.Data.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllRole();
        Role GetRoleByRoleId(int id);
        void SaveRoleDetails(Role objRole);
        void UpdateRoleDetails(Role objRole);
        void DeleteRoleDetails(int id);
    }
}
