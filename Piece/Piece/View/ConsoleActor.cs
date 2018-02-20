using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public abstract class ConsoleActor : Actor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">Actor's X Tile position.</param>
        /// <param name="y">Actor's Y Tile position.</param>
        /// <param name="tileWidth">Width of a tile.</param>
        /// <param name="tileHeight">Height of a tile.</param>
        public ConsoleActor(float x = 0, float y = 0, float tileWidth = 1, float tileHeight = 1) : base(x, y, tileWidth, tileHeight)
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
                for (int j = 0; j < (int)w; j++)
                {
                    Console.SetCursorPosition((int)(x * w + i), (int)(y * h + j));
                    Console.Write(GetSymbol());
                }
            }
        }

        /// <summary>
        /// Method for getting the symbol representing actor.
        /// </summary>
        /// <returns>Character representing actor.</returns>
        public abstract char GetSymbol();
    }
}
