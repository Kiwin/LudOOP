using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludoop.Backend
{
    /// <summary>
    /// Class representing a player.
    /// </summary>
    public class Player : ITeam, IName
    {
        public Player(string name, PlayerTeam team)
        {
            this.Name = name;
            this.Team = team;
        }

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

        private List<Piece> piecesOnBoard;
        private int pieceBuffer;

        public int PieceBuffer
        {
            get { return pieceBuffer; }
            set { this.pieceBuffer = value; }
        }

        public void SpawnPiece(Tile tile)
        {
            foreach (PieceType shape in Enum.GetValues(typeof(PieceType)))
            {
                // if PieceShape is not present in pieces
                if (!piecesOnBoard.Any(piece => piece.Type == shape))
                {
                    piecesOnBoard.Add(new Piece(Team, shape, tile));
                    PieceBuffer += PieceBuffer - 1;
                }
            }
        }
    }
}
