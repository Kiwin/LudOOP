using System;
using System.Reflection.Metadata.Ecma335;
using Ludoop;
using Ludoop.Backend;
using Ludoop.Backend.MapLayouts;
using Ludoop.Backend.Tiles;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var scale = 1;
			var camX = 0;
			var camY = 0;

			var players = new Player[] {
				new Player("P1", PlayerTeam.GREEN),
				new Player("P2", PlayerTeam.RED),
				};

			var gameBoard = new LudoGameBoard();
			var ruleSet = new LudoRuleSet();

			Game game = new Game(players, 4, 6, ruleSet);

			while (true)
			{


				Console.Clear();
				gameBoard.Draw();

				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.Add:
						scale++;
						break;
					case ConsoleKey.Subtract:
						scale--;
						break;
					case ConsoleKey.NumPad6:
						camX--;
						break;
					case ConsoleKey.NumPad4:
						camX++;
						break;
					case ConsoleKey.NumPad8:
						camY++;
						break;
					case ConsoleKey.NumPad2:
						camY--;
						break;
				}

				var renderConfig = Game.GetConsoleRenderConfig();
				renderConfig.ColumnScale = scale;
				renderConfig.RowScale = scale;
				renderConfig.ColumnOffset = camX;
				renderConfig.RowOffset = camY;
			}
		}
	}
}
