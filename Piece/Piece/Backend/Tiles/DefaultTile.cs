using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.View;

namespace Ludoop.Backend.Tiles
{
    /// <summary>
    /// Class representing a default tile.
    /// </summary>
    public class DefaultTile : Tile
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="map">Map which the tile is within.</param>
        public DefaultTile(Map map, int index, Actor actor) : base(TileType.DEFAULT, map, index, actor) {
            this.Actor = new ConsoleTileActor(Game.GetConsoleActorMatrix(), this);
        }

        /// <summary>
        /// Actor Getter and Setter.
        /// </summary>
        public override Actor Actor { get; set; }
    }
}
