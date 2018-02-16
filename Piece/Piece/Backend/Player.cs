using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// Class representing a player.
    /// </summary>
    public class Player : IPlayer
    {

        private string name;
        public string Name {
            get { return name; }
            set { this.name = value; }
        }

        private PlayerTeam team;

        public PlayerTeam Team {
            get { return team; }
            set { this.team = value; }
        }

        private List<Piece> pieces;

        public void SpawnPiece(Tile tile)
        {
            foreach (PieceShape shape in Enum.GetValues(typeof(PieceShape)))
            {
                // if PieceShape is not present in pieces
                if (!pieces.Any(piece => piece.Shape == shape))
                {
                    Piece newPiece = new Piece(Team, shape, tile);
                }
            }
        }
    }
}
