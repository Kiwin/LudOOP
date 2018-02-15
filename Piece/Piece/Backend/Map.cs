using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class Map
    {
        public Map(int size)
        {
            tiles = new Tile[size];
        }

        public Tile[] tiles;
        public Tile[] Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }

        public Tile[] GetTilesOfType(TileType tileType)
        {
            List<Tile> tilesOfType = new List<Tile>();
            Array.ForEach(Tiles, tile => { if (tile.Type == tileType) tilesOfType.Add(tile); });
            return tilesOfType.ToArray();
        }

    }
}
