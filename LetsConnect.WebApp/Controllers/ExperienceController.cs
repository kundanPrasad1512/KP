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
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this._experienceService = experienceService;
        }

        [HttpGet]
        public IQueryable<Experience> GetAllExperience()
        {
            return _experienceService.GetAllExperience();
        }


        [HttpGet]
        [Route("{id:int}")]
        public Experience GetExperienceByExperienceId(int id)
        {
            return _experienceService.GetExperienceByExperienceId(id);
        }


        [HttpPost]
        public HttpResponseMessage SaveExperienceDetails([FromBody] Experience objExperience)
        {
            try
            {
                _experienceService.SaveExperienceDetails(objExperience);
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
        public void UpdateExperienceDetails([FromBody] Experience objExperience)
        {
            _experienceService.UpdateExperienceDetails(objExperience);
        }


        [HttpDelete]
        [Route("{id}")]
        public void DeleteExperienceDetails(int id)
        {
            _experienceService.DeleteExperienceDetails(id);
        }
    }
}
