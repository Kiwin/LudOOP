using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public abstract class ConsoleActor : Actor
    {

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="x">Actor's X Tile position.</param>
        /// <param name="y">Actor's Y Tile position.</param>
        /// <param name="tileWidth">Width of a tile.</param>
        /// <param name="tileHeight">Height of a tile.</param>
        public ConsoleActor(int x = 0, int y = 0, int tileWidth = 1, int tileHeight = 1, int tileSpacingX = 0, int tileSpacingY = 0) : base(x, y, tileWidth, tileHeight)
        {

        }

        /// <summary>
        /// Method for drawing actor.
        /// </summary>
        /// <param name="x">Tile X position to draw actor at.</param>
        /// <param name="y">Tile Y position to draw actor at.</param>
        /// <param name="w">Amount of symbols to draw horizontally.</param>
        /// <param name="h">Amount of symbols to draw vertically.</param>
        public override void Draw(float x, float y, float w, float h)
        {
            for (int i = 0; i < (int)w; i++)
            {
                Console.ForegroundColor = GetForegroundColor();
                Console.BackgroundColor = GetBackgroundColor();

                for (int j = 0; j < (int)h; j++)
                {
                    Console.SetCursorPosition((int)(x * w + i), (int)(y * h + j));
                    Console.Write(GetSymbol());
                }
            }
        }

        /// <summary> hej Kiwin
        /// Method for getting the symbol representing actor.
        /// </summary>
        /// <returns>Character representing actor.</returns>
        public abstract char GetSymbol();

        /// <summary>
        /// Method for getting the actor foreground color.
        /// </summary>
        /// <returns>Actor's foreground color.</returns>
        public abstract ConsoleColor GetForegroundColor();

        /// <summary>
        /// Method for getting the actor background color.
        /// </summary>
        /// <returns>Actor's background color.</returns>
        public abstract ConsoleColor GetBackgroundColor();

    }
}
