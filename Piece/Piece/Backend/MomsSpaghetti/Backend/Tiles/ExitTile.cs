using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoLudo.View;

namespace PseudoLudo.Backend.Pieces
{
    public class ExitTile : Tile, ITeam
    {

        public ExitTile(Map map, int index, Tile destinationTile, Team team) : base(TileType.EXIT, map, index)
        {
            this.DestinationTile = destinationTile;
            this.Team = team;
        }

        public Tile DestinationTile { get; set; }
        public override Actor Actor { get; set; }
        public Team Team { get; set; }

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
