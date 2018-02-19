using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.View;

namespace Ludoop.Backend
{
    /// <summary>
    /// Class representing an map-exit tile.
    /// </summary>
    public class ExitTile : Tile, ITeam
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="map">Map tile is within.</param>
        /// <param name="index">Index of tile in map.</param>
        /// <param name="destinationTile">Tile which to redirect to if piece team matches.</param>
        /// <param name="team">Team which the tile should redirect.</param>
        public ExitTile(Map map, int index, Tile destinationTile, PlayerTeam team) : base(TileType.EXIT, map, index)
        {
            this.DestinationTile = destinationTile;
            this.Team = team;
        }

        /// <summary>
        /// DistinationTile Getter and setter.
        /// </summary>
        public Tile DestinationTile { get; set; }

        /// <summary>
        /// actor Getter and setter for distinationTile.
        /// </summary>
        public override Actor actor { get; set; }
        
        /// <summary>
        /// Getter and setter for Team.
        /// </summary>
        public PlayerTeam Team { get; set; }

        public override void onPieceLeave(Piece piece, bool isForward, bool isLast)
        {
            if (piece.Team == this.Team)
            {
                piece.CurrentTile = this.DestinationTile;
                return;
            }
            else
            {
                base.onPieceLeave(piece, isForward, isForward);
            }
        }
    }
}