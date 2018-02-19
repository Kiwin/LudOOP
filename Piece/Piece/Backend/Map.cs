using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class Map : IName
    {
        public Tile[] Tiles;
        bool isLoopMap;

        public Map(int size, bool isLoopMap)
        {
            this.Tiles = new Tile[size];
            this.isLoopMap = isLoopMap;
            this.Name = "Map";
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i] = new DefaultTile(this, i);
            }
        }

        public void SetTile(int tileIndex, Tile tile)
        {
            if (tileIndex >= 0 && tileIndex < Tiles.Length)
            {
                Tiles[tileIndex] = tile;
                if (tileIndex != Tiles.Length - 1)
                {
                    tile.NextTile = Tiles[tileIndex + 1];
                }
                else if (isLoopMap)
                {
                    tile.NextTile = Tiles[0];
                }
                if (tileIndex != 0)
                {
                    tile.PrevTile = Tiles[tileIndex - 1];
                }
                else if (isLoopMap)
                {
                    tile.NextTile = Tiles[Tiles.Length - 1];
                }
            }
        }

        public Tile LastTile
        {
            get { return this.Tiles[Tiles.Length - 1]; }
            set { this.Tiles[Tiles.Length - 1] = value; }
        }
        public Tile FirstTile
        {
            get { return this.Tiles[0]; }
            set { this.Tiles[0] = value; }
        }

        public string Name { get; set; }

        public string[] GetTilesInfo()
        {
            string[] tileInfo = new string[Tiles.Length];
            int i = 0;
            foreach (Tile tile in Tiles)
            {
                tileInfo[i] = GetTileInfo(tile.Index);
                i++;
            }
            return tileInfo;
        }

        public string GetTileInfo(int index)
        {
            Tile tile = Tiles[index];
            string strMap = tile.Map.Name;
            string strIdx = tile.Index.ToString();
            string strType = tile.TYPE.ToString();
            string strInfo = strMap + ":" + strIdx + ":" + strType;
            if (tile is ITeam) //Add Team Info
            {
                string strTeam = Enum.GetName(typeof(PlayerTeam), ((ITeam)tile).Team);
                strInfo += ":" + strTeam;
            }
            if (tile is ExitTile) //Add Destination Tile Info
            {
                Tile destinationTile = ((ExitTile)tile).DestinationTile;
                strInfo += "\t->\t" + destinationTile.Map.GetTileInfo(destinationTile.Index);
            }
            return strInfo;
        }
    }
}
