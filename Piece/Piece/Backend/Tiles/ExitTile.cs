using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.View;

namespace Ludoop.Backend.Tiles
{
    public class ExitTile : Tile, ITeam
    {

        public ExitTile(Map map, int index, Tile destinationTile, PlayerTeam team) : base(TileType.EXIT, map, index)
        {
            this.DestinationTile = destinationTile;
            this.Team = team;
            this.Actor = new ConsoleTileActor(Game.GetConsoleActorMatrix(), this);
        }

        public Tile DestinationTile { get; set; }
        public override Actor Actor { get; set; }
        public PlayerTeam Team { get; set; }

        public override Tile GetNextTile(Piece piece)
        {
            if (piece.Team == this.Team)
            {
                return DestinationTile;
            }
            else
            {
                return NextTile;
            }
        }
    }
}