using PseudoLudo.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoLudo.Backend
{

    public class Player : ITeam, IName
    {
        public Player(string name, Team team)
        {
            this.Name = name;
            this.Team = team;
        }

        public Team Team { get; set; }
        public string Name { get; set; }
    }
}
