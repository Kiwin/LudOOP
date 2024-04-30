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
		/// <param name="column">Tile X position to draw actor at.</param>
		/// <param name="row">Tile Y position to draw actor at.</param>
		/// <param name="width">Amount of symbols to draw horizontally.</param>
		/// <param name="height">Amount of symbols to draw vertically.</param>
		public override void Draw(float column, float row, float width, float height)
		{
			int w = (int)(width * RenderConfig.ColumnScale);
			for (int i = 0; i < w; i++)
			{
				float x = i + column * RenderConfig.ColumnScale;
				int left = (int)(RenderConfig.ColumnOffset + x);
				if (left < 0) continue;
				if (left >= Console.BufferWidth) break;

				int h = (int)(height * RenderConfig.RowScale);
				for (int j = 0; j < h; j++)
				{
					float y = j + row * RenderConfig.RowScale;
					int top = (int)(RenderConfig.RowOffset + y);
					if (top < 0) continue;
					if (top >= Console.BufferHeight) break;

					Console.ForegroundColor = GetForegroundColor();
					Console.BackgroundColor = GetBackgroundColor();
					Console.SetCursorPosition(left, top);
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
