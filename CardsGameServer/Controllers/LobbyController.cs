using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using CardsGameServer.Hubs;
using CardsGameServer.Models;

namespace CardsGameServer.Controllers
{
    [Route("api/lobby")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly IHubContext<LobbyHub> _hubContext;
        private int numbersOfPlayers;

        public LobbyController(IHubContext<LobbyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("sendPlayerNameConnection")]
        [HttpPost]
        public IActionResult SendPlayerNameAndFullLobby([FromBody] PlayerDto player)
        {
            LobbyHub lobby = new LobbyHub();
            numbersOfPlayers = lobby.numbersOfPlayers;
            _hubContext.Clients.All.SendAsync("PlayerJoined", player.userName, player.description, numbersOfPlayers);
            return Ok();
        }
    }
}
