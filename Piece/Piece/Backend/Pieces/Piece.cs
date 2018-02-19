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

        public Piece(PieceType type, Tile tile)
        {
            this.Type = type;
            this.CurrentTile = tile;
        }

        public PlayerTeam Team { get; set; }

        public void Move(int steps)
        {
            bool isMovingForward = steps > 0;
            steps = Math.Abs(steps);

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

        public void WarpTo(Tile tile)
        {
            CurrentTile = tile;
        }
    }
}
