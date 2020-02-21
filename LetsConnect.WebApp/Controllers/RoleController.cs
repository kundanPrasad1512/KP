using LetsConnect.Models;
using LetsConnect.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace LetsConnect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;   
        }


        //[Route("api/Role/GetAllRole")]
        [HttpGet]
        public IQueryable<Role> GetAllRole()
        {
            return _roleService.GetAllRole();
        }


        [HttpGet]
        [Route("{id:int}")]
        public Role GetRoleByRoleId(int id)
        {
            return _roleService.GetRoleByRoleId(id);
        }


        [HttpPost]       
        public HttpResponseMessage SaveRoleDetails([FromBody] Role objRole)
        {
            try
            {
                _roleService.SaveRoleDetails(objRole);
                var message = new HttpResponseMessage(HttpStatusCode.Created);

                return message;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return message;
            }

        }


        [HttpPut]
        public HttpResponseMessage UpdateRoleDetails([FromBody] Role objRole)
        {
            try
            {
                _roleService.UpdateRoleDetails(objRole);
                var message = new HttpResponseMessage(HttpStatusCode.Created);
                return message;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return message;
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteRoleDetails(int id)
        {
            try
            {
                _roleService.DeleteRoleDetails(id);
                var message = new HttpResponseMessage(HttpStatusCode.Created);
                return message;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return message;
            }

        }
    }
}
