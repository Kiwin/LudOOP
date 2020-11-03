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
        /// <param name="row">Row position in the console.</param>
        /// <param name="column">Column position in the console.</param>
        /// <param name="width">Amount of rows to fill.</param>
        /// <param name="height">Amount of columns to fill.</param>
        public ConsoleActor(ConsoleRenderConfig renderConfig, int row = 0, int column = 0, int width = 1, int height = 1) : base(row, column, width, height)
        {
            this.RenderConfig = renderConfig;
        }

        public ConsoleRenderConfig RenderConfig { get; set; }

        /// <summary>
        /// Method for drawing actor.
        /// </summary>
        /// <param name="x">Tile X position to draw actor at.</param>
        /// <param name="y">Tile Y position to draw actor at.</param>
        /// <param name="width">Amount of symbols to draw horizontally.</param>
        /// <param name="height">Amount of symbols to draw vertically.</param>
        public override void Draw(float x, float y, float width, float height)
        {
            for (int i = 0; i < (int)(width * RenderConfig.RowScale); i++)
            {
                Console.ForegroundColor = GetForegroundColor();
                Console.BackgroundColor = GetBackgroundColor();

                for (int j = 0; j < (int)(height * RenderConfig.ColumnScale); j++)
                {
                    Console.SetCursorPosition((int)(RenderConfig.RowOffset + x * (width + RenderConfig.RowSpacing) + i), (int)(RenderConfig.ColumnOffset + y * (height + RenderConfig.ColumnSpacing) + j));
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
