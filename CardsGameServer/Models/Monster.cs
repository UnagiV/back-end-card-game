using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsGameServer.Models
{
    public class Monster
    {
        public int id { get; set; }
        public string name { get; set; }
        public int lifePoints { get; set; }
        public int abilitieStackNeeded { get; set; }
        public string capacity { get; set; }
        public string color { get; set; }
    }
}
