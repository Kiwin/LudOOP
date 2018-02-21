using System;
using System.Collections.Generic;
using System.Text;
using Ludoop.Backend.Tiles;

namespace Ludoop.Backend
{
    public class Map : IName
    {
        /// <summary>
        /// Array of Tile objects.
        /// </summary>
        public Tile[] Tiles;

        /// <summary>
        /// Flag for checking if map is a loop.
        /// </summary>
        bool isLoopMap;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="size">Size of the map.</param>
        /// <param name="isLoopMap">Flag for checking if map is a loop.</param>
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

        /// <summary>
        /// Method for replacing a specified map tile.
        /// </summary>
        /// <param name="tileIndex">Index of tile to set.</param>
        /// <param name="tile">Instance of new tile</param>
        public void SetTile(int tileIndex, Tile tile)
        {
            if (tileIndex >= 0 && tileIndex < Tiles.Length) //Check if tileIndex is a valid array index.
            {
                Tiles[tileIndex] = tile;
                if (tileIndex != Tiles.Length - 1) //Check if tile is not last tile.
                {
                    tile.NextTile = Tiles[tileIndex + 1];
                }
                else if (isLoopMap) //Else check if map is loopmap.
                {
                    tile.NextTile = this.FirstTile;
                }
                if (tileIndex != 0) //Check if tile is not first tile.
                {
                    tile.PrevTile = Tiles[tileIndex - 1];
                }
                else if (isLoopMap) //Else check if map is loopmap.
                {
                    tile.PrevTile = this.LastTile;
                }
            }
        }

        //Getter and Setter for the last tile of the map.
        public Tile LastTile
        {
            get { return this.Tiles[Tiles.Length - 1]; }
            set { this.Tiles[Tiles.Length - 1] = value; }
        }
        //Getter and Setter for the first tile of the map.
        public Tile FirstTile
        {
            get { return this.Tiles[0]; }
            set { this.Tiles[0] = value; }
        }

        //Map name Getter and Setter.
        public string Name { get; set; }

        /// <summary>
        /// Method for getting an info-string about all tiles.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method for getting an info-string for a tile specified by index.
        /// </summary>
        /// <param name="index">Index of tile</param>
        /// <returns></returns>
        public string GetTileInfo(int index)
        {
            Tile tile = Tiles[index];
            string strMap = tile.Map.Name;
            string strIdx = tile.Index.ToString();
            string strType = tile.TYPE.ToString();
            string strPos = String.Format("[x:{0},y:{1},w:{2},h:{3}]", tile.Actor.X, tile.Actor.Y, tile.Actor.Width, tile.Actor.Height);
            string strInfo = strMap + ":" + strIdx + ":" + strType + ":" + strPos;
            if (tile is ITeam) //Check if should add Team Info.
            {
                string strTeam = Enum.GetName(typeof(PlayerTeam), ((ITeam)tile).Team);
                strInfo += ":" + strTeam;
            }
            if (tile is ExitTile) //Check if should add ExitTile Destination Info.
            {
                Tile destinationTile = ((ExitTile)tile).DestinationTile;
                strInfo += "\t->\t" + destinationTile.Map.GetTileInfo(destinationTile.Index);
            }
            return strInfo;
        }
        public Tile[] GetNextTilesOfType(TileType type)
        {
            List<Tile> tilesOfType = new List<Tile>();
            foreach (Tile tile in this.Tiles)
            {
                if (tile.TYPE == type)
                {
                    tilesOfType.Add(tile);
                }
            }
            return tilesOfType.ToArray();
        }
        public Tile GetFirstTileOfTeam(Tile[] tiles, PlayerTeam team) {
            foreach (Tile tile in tiles) {
                if (tile is ITeam && ((ITeam)tile).Team == team) {
                    return tile;
                }
            }
            return null;
        }
    }
}
