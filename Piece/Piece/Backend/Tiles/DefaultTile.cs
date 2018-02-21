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
        public DefaultTile(Map map, int index) : base(TileType.DEFAULT, map, index) {
            this.Actor = new ConsoleTileActor(this);
        }

        /// <summary>
        /// Actor Getter and Setter.
        /// </summary>
        public override Actor Actor { get; set; }
    }
}
