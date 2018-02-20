﻿using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public class ConsoleTileActor : ConsoleActor
    {
        private Tile tile;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="tile">Tile of actor.</param>
        public ConsoleTileActor(Tile tile)
        {
            this.tile = tile;
        }

        /// <summary>
        /// Method for getting the symbol representing actor.
        /// </summary>
        /// <returns>Character representing actor.</returns>
        public override char GetSymbol()
        {
            switch (tile.TYPE)
            {
                case TileType.DEFAULT:
                    { return '-'; }
                case TileType.END:
                    { return '='; }
                case TileType.EXIT:
                    { return '>'; }
                case TileType.GLOBE:
                    { return '*'; }
                case TileType.SPAWNPOINT:
                    { return 's'; }
                case TileType.STAR:
                    { return '+'; }
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
                Game.GetTeamColor(((ITeam)tile).Team);
            }
            return ConsoleColor.Black;
        }
    }
}