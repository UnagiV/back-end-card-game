using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsGameServer.Hubs
{
    public class LobbyHub : Hub
    {
        public Task SendPlayerNameConnection(string userName, string description)
        {
            return Clients.All.SendAsync("PlayerJoined", userName, description); 
        }
    }
}
