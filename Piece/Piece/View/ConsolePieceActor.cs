using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.Backend;

namespace Ludoop.View
{
    public class ConsolePieceActor : ConsoleActor
    {

        private Piece piece;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="piece">Piece of actor.</param>
        public ConsolePieceActor(ConsoleActorMatrix matrix, Piece piece, int x = 0, int y = 0, int w = 1, int h = 1) : base(matrix, x, y, w, h)
        {
            this.piece = piece;
        }

        /// <summary>
        /// Method for getting the actor foreground color.
        /// </summary>
        /// <returns>Actor's foreground color.</returns>
        public override ConsoleColor GetForegroundColor()
        {
            return Game.GetTeamColor(piece.Team);
        }

        /// <summary>
        /// Method for getting the actor background color.
        /// </summary>
        /// <returns>Actor's background color.</returns>
        public override ConsoleColor GetBackgroundColor()
        {
            return ConsoleColor.Black;
        }

        /// <summary>
        /// Method for getting the symbol representing actor.
        /// </summary>
        /// <returns>Character representing actor.</returns>
        public override char GetSymbol()
        {
            switch (piece.Type)
            {
                case PieceType.CIRCLE:
                    { return 'C'; }
                case PieceType.PENTAGON:
                    { return 'P'; }
                case PieceType.SQUARE:
                    { return 'S'; }
                case PieceType.TRIANGLE:
                    { return 'T'; }
                default:
                    { return '?'; }
            }
        }
    }
}
