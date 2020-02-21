using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsConnect.WebApp.SignalRHub.Hubs
{
    public class LetsConnectHub:Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        //public Task SendToAll(string name, string message)
        //{
        //    return Clients.All.SendAsync("ReceiveMessage", name, message);
        //}
        public void SendToAll(string name, string message)
        {
            Clients.All.SendAsync("sendToAll", name, message);
        }

        //public string GetConnectionId()
        //{
        //    return Context.ConnectionId;
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, "left");
        //}

        public async Task ReceiveMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }
    }
}
