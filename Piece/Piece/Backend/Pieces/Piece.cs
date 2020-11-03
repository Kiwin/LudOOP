using Ludoop.Backend;
using Ludoop.Backend.Tiles;
using Ludoop.View;
using System;

namespace Ludoop.Backend
{
    public class Piece : ITeam, IAct
    {

        public Tile CurrentTile { get; set; }
        public Tile LastTile { get; set; }
        public PieceType Type;
        public bool IsFinished = false;
        public PlayerTeam Team { get; set; }
        public Actor Actor { get; set; }
        /// <summary>
        /// Constructor for the piece class
        /// </summary>
        /// <param name="type">the type of piece works along with the current team of the piece as an ID</param>
        /// <param name="tile">defines the current tile the piece is on</param>
        public Piece(PlayerTeam team, PieceType type, Tile tile)
        {
            this.Type = type;
            this.CurrentTile = tile;
            this.Team = team;
            this.Actor = new ConsolePieceActor(Game.GetConsoleRenderConfig(), this);
        }

        /// <summary>
        /// Moves the piece a set amount of steps
        /// </summary>
        /// <param name="steps">the amount of steps to move</param>
        public void Move(int steps)
        {
            // kind of misleading, is only used with the onmove event to 
            Tile previousTile = CurrentTile;

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
            OnMove(this, previousTile, CurrentTile);
        }

        // "Warps" to the tile in question instead of stepping 
        public void WarpTo(Tile tile)
        {
            Tile oldTile = CurrentTile;
            CurrentTile = tile;
            OnMove(this, oldTile, CurrentTile);
        }

        public void RemovePiece()
        {
            OnRemove(this);
        }

        public delegate void PieceMovedHandler(Piece piece, Tile previousTile, Tile newTile);
        public event PieceMovedHandler OnMove;

        public delegate void OnRemovedHandler(Piece piece);
        public event OnRemovedHandler OnRemove;
    }
}
