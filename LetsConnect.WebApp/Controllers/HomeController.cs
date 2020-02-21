using LetsConnect.WebApp.SignalRHub.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LetsConnect.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        IHubContext<LetsConnectHub> _chatHubContext;
        public HomeController(IHubContext<LetsConnectHub> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public void SendMessage(string msg)
        {
            _chatHubContext.Clients.All.SendAsync("ReceiveMessage", "test", msg);           
        }

    }
}
