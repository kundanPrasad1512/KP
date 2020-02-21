using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsConnect.Entities.Models;
using LetsConnect.Models;
using LetsConnect.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LetsConnect.WebApp.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        IUserervice _Userervice;
        private IConfiguration _config;
        public AuthController(IConfiguration config, IUserervice Userervice)
        {
            _config = config;
            this._Userervice = Userervice;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login loginModel)
        {
            IActionResult response = Unauthorized();

            User user =_Userervice.ValidateUser(loginModel.UserName, loginModel.Password);
            
            if (user != null)
            {
                string name = user.FirstName + " " + user.LastName;
                int userId = user.UserID;
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString,name= name,userID= userId });
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}