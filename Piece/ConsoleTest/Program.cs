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

			while (true)
			{

				var players = new Player[] {
				new Player("P1", PlayerTeam.GREEN),
				new Player("P2", PlayerTeam.RED),
			};

				var gameBoard = new LudoGameBoard();
				var ruleSet = new RuleSet(gameBoard);

				Game game = new Game(players, 4, 6, ruleSet);

				var consoleRenderConfig = Game.GetConsoleRenderConfig();
				gameBoard.Draw(0, 0, scale, scale);
				scale++;
				Console.ReadKey();
			}

		}
	}
}
