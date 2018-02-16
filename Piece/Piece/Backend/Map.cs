using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class Map : IName
    {
        public Map(int size)
        {
            tiles = new Tile[size];
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i] = new DefaultTile(this);
            }
        }

        public Tile[] tiles;
        public Tile[] Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        
        public Tile[] GetTilesOfType(TileType tileType)
        {
            List<Tile> tilesOfType = new List<Tile>();
            Array.ForEach(Tiles, tile => { if (tile.Type == tileType) tilesOfType.Add(tile); });
            return tilesOfType.ToArray();
        }

        /// <summary>
        /// Method for getting the index of a specified Tile.
        /// </summary>
        /// <param name="tile">Tile to search for.</param>
        /// <returns>Returns index of specified Tile. Returns -1 if tile was not found.</returns>
        public int GetIndexOfTile(Tile tile)
        {
            Tile currTile;
            for (int i = 0; i < Tiles.Length; i++)
            {
                currTile = Tiles[i];
                if (currTile == tile) { return i; }
            }
            return -1;
        }

    }
}
