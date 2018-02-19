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
        /// <summary>
        /// Initializes the Player Class with a name and a team
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="team">The Team of the player (PlayerTeam is defined in ITeam.cs)</param>
        public Player(string name, PlayerTeam team)
        {
            this.Name = name;
            this.Team = team;
        }

        /// <summary>
        /// Container for the name of the player
        /// </summary>
        private string name;
        public string Name {
            get { return name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Container for the Team 
        /// </summary>
        private PlayerTeam team;
        public PlayerTeam Team {
            get { return team; }
            set { this.team = value; }
        }

        /// <summary>
        /// List of all pieces owned by the player currently on the board
        /// </summary>
        private List<Piece> piecesOnBoard;

        /// <summary>
        /// Value representing the pieces not currently on the board
        /// </summary>
        private int pieceBuffer;
        public int PieceBuffer
        {
            get { return pieceBuffer; }
            set { this.pieceBuffer = value; }
        }

        /// <summary>
        /// Spawns a piece on an arbitrary tile in the case of Ludo on the starting tile for the player
        /// </summary>
        /// <param name="tile"></param>
        public void SpawnPiece(Tile tile)
        {
            // Used to specify the shape of the piece this along with the team of the Piece is used to define the ID of the piece
            foreach (PieceType shape in Enum.GetValues(typeof(PieceType)))
            {
                // if PieceShape is not present in pieces
                if (!piecesOnBoard.Any(piece => piece.Type == shape))
                {
                    // TODO: Currently not implemented due to Piece being abstract and needs subclasses
                    piecesOnBoard.Add(new Piece(Team, shape, tile));
                    PieceBuffer += PieceBuffer - 1;
                }
            }
        }
    }
}
