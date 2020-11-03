using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.Backend.Tiles;

namespace Ludoop.View
{
    public class ConsoleTileActor : ConsoleActor
    {
        private readonly Tile tile;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="tile">Tile of actor.</param>
        public ConsoleTileActor(ConsoleRenderConfig renderConfig, Tile tile, int x = 0, int y = 0, int w = 1, int h = 1) : base(renderConfig, x, y, w, h)
        {
            this.tile = tile;
        }

        /// <summary>
        /// Method for getting the symbol representing actor.
        /// </summary>
        /// <returns>Character representing actor.</returns>
        public override char GetSymbol()
        {
            switch (tile.Type)
            {
                case TileType.DEFAULT:
                    { return (tile.Actor.X + tile.Actor.Y) % 2 == 0 ? '-' : '|'; }
                case TileType.END:
                    { return '='; }
                case TileType.EXIT:
                    { return '>'; }
                case TileType.GLOBE:
                    { return 'o'; }
                case TileType.SPAWNPOINT:
                    { return '+'; }
                case TileType.STAR:
                    { return '*'; }
                default:
                    { return '?'; }
            }
        }
        /// <summary>
        /// Method for getting the actor foreground color.
        /// </summary>
        /// <returns>Actor's foreground color.</returns>
        public override ConsoleColor GetForegroundColor()
        {
            return ConsoleColor.White;
        }

        /// <summary>
        /// Method for getting the actor background color.
        /// </summary>
        /// <returns>Actor's background color.</returns>
        public override ConsoleColor GetBackgroundColor()
        {
            if (tile is ITeam)
            {
                return Game.GetTeamColor(((ITeam)tile).Team);
            }
            return ConsoleColor.Black;
        }
    }
}
