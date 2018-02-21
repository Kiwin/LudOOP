using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludoop.View;


namespace Ludoop.Backend.Tiles
{
    class EndTile : Tile, ITeam
    {
        public EndTile(Map map, int index, PlayerTeam team) : base(TileType.END, map, index) {
            this.Team = team;
        }

        public override Actor Actor { get; set; }
        public PlayerTeam Team { get; set; }
    }
}
