using LetsConnect.Models;
using LetsConnect.Service.Services;
using LetsConnect.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace LetsConnect.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TechnologiesController : Controller
    {
        ITechnologiesService _technologiesService;

        public TechnologiesController(ITechnologiesService technologiesService)
        {
            this._technologiesService = technologiesService;
        }

        [HttpGet]
        public IEnumerable<Technologies> GetAllTechnologies()
        {
            return _technologiesService.GetAllTechnologies();
        }


        [HttpGet]
        [Route("{id}")]
        public Technologies GetTechnologiesByTechnologiesId(int id)
        {
            return _technologiesService.GetTechnologiesByTechnologiesId(id);
        }


        [HttpPost]
        public HttpResponseMessage SaveTechnologiesDetails([FromBody] Technologies objTechnologies)
        {
            try
            {
                _technologiesService.SaveTechnologiesDetails(objTechnologies);
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
        public void UpdateTechnologiesDetails([FromBody] Technologies objTechnologies)
        {
            _technologiesService.UpdateTechnologiesDetails(objTechnologies);
        }


        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteTechnologiesDetails(int id)
        {
            try
            {
                _technologiesService.DeleteTechnologiesDetails(id);
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
