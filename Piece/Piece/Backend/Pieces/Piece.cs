using Ludoop.Backend;
using System;

namespace Ludoop.Backend
{
    public enum PieceType { CIRCLE, SQUARE, TRIANGLE, PENTAGON };

    public abstract class Piece : ITeam
    {

        public Tile CurrentTile { get; set; }
        public Tile LastTile { get; set; }
        public PieceType Type;

        /// <summary>
        /// Constructor for the piece class
        /// </summary>
        /// <param name="type">the type of piece works along with the current team of the piece as an ID</param>
        /// <param name="tile">defines the current tile the piece is on</param>
        public Piece(PieceType type, Tile tile)
        {
            this.Type = type;
            this.CurrentTile = tile;
        }

        public PlayerTeam Team { get; set; }

        /// <summary>
        /// Moves the piece a set amount of steps
        /// </summary>
        /// <param name="steps">the amount of steps to move</param>
        public void Move(int steps)
        {
            // Determines whether the piece is moving backwards or forwards
            bool isMovingForward = steps > 0;
            // sets an absolute value to the amount of steps
            steps = Math.Abs(steps);

            // "steps" once for every 1 in steps (moves the piece whatever many times it needs)
            for (int i = 0; i < steps; i++)
            {
                bool isLastStep = (i == steps - 1);
                LastTile = CurrentTile;
                CurrentTile.onPieceLeave(this, isMovingForward, isLastStep);
                if (CurrentTile != LastTile)
                {
                    CurrentTile.onPieceEnter(this, isMovingForward, isLastStep);
                }
            }
        }

        // "Warps" to the tile in question instead of stepping 
        public void WarpTo(Tile tile)
        {
            CurrentTile = tile;
        }
    }
}
