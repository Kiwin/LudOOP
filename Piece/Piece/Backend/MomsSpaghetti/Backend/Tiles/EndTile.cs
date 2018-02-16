using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoLudo.View;

namespace PseudoLudo.Backend.Tiles
{
    class EndTile : Tile, ITeam
    {
        public EndTile(Map map, int index, Team team) : base(TileType.END, map, index) {
            this.Team = team;
        }

        public override Actor Actor { get; set; }
        public Team Team { get; set; }
    }
}
