using CardsGameServer.Models;
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

        public Task AlerFirstPlayer()
        {
            return Clients.All.SendAsync("FirstPlayer", true);
        }

        public void SendGameStartAlert(string[] playersList)
        {
            AlertGameStarted(playersList);
        }

        public void SendSkipTurn(string playerName)
        {
            AlerPlayerTurn(playerName);
        }

        public Task AlerPlayerTurn(string playerName)
        {
            return Clients.All.SendAsync("YourTurn", playerName);
        }

        public Task AlertGameStarted(string[] playersList)
        {
            return Clients.All.SendAsync("GameStart", playersList);
        }

        public Task SendPlayerInfo(string[] playerInfos)
        {
            return Clients.All.SendAsync("PlayerInfos", playerInfos);
        }


        public Task SendPlayerNameConnection(string playerName)
        {
            return Clients.All.SendAsync("PlayerJoined", playerName);
        }

        public void SendLogin(string playerName)
        {
            if(numbersOfPlayers == 1)
            {
                AlerFirstPlayer();
            }
            SendPlayerNameConnection(playerName);
        }

    }
}
