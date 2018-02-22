using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludoop.View;

namespace Ludoop.Backend.Tiles
{
    public class SpawnTile : Tile, ITeam
    {

        /// <summary>
        /// Defines a tile that a piece can spawn on
        /// </summary>
        /// <param name="map">the map the tile is on</param>
        /// <param name="index">the index the tile is on</param>
        /// <param name="team">the team the spawntile is assigned to</param>
        public SpawnTile(Map map, int index, PlayerTeam team, Actor actor) : base(TileType.SPAWNPOINT, map, index, actor)
        {
            this.Team = team;
            this.Actor = new ConsoleTileActor(this);
        }

        public override Actor Actor { get; set; }
        public PlayerTeam Team { get; set; }
    }
}
