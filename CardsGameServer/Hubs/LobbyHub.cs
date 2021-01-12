using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsGameServer.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }
    public class LobbyHub : Hub
    {
        public int numbersOfPlayers = UserHandler.ConnectedIds.Count;
        public override Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        public Task SendPlayerNameConnection(string userName, string description)
        {
            numbersOfPlayers = UserHandler.ConnectedIds.Count;
            return Clients.All.SendAsync("PlayerJoined", userName, description, numbersOfPlayers); 
        }
    }
}
