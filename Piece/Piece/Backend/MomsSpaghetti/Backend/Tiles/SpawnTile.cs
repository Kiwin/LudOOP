using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoLudo.View;

namespace PseudoLudo.Backend.Tiles
{
    public class SpawnTile : Tile, ITeam
    {

        public SpawnTile(Map map, int index, Team team) : base(TileType.SPAWN, map, index)
        {
            this.Team = team;
        }

        public override Actor Actor { get; set; }
        public Team Team { get; set; }
    }
}
