using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class ExitTile : Tile, ITeam
    {

        public ExitTile(Map map, int index, Tile destinationTile, PlayerTeam team) : base(TileType.EXIT, map, index)
        {
            this.DestinationTile = destinationTile;
            this.Team = team;
        }

        public Tile DestinationTile { get; set; }
        public override Actor Actor { get; set; }
        public PlayerTeam Team { get; set; }

        public override void onPieceLeave(Piece piece, bool isForward, bool isLast)
        {
            {
                if (isLast && piece.Team == this.Team)
                {
                    piece.CurrentTile = this.DestinationTile;
                }
            }
        }
    }
}