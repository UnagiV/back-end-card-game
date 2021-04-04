using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsGameServer.Models
{
    public class Player
    {
        public string pseudo { get; set; }
        public Monster monsters { get; set; }
    }
}
