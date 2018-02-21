using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    public enum MapSection { SHARED, RED, BLUE, YELLOW, GREEN };
    public enum MapSectionSize { SHARED = 52, RED = 4, BLUE = 4, YELLOW = 4, GREEN = 4 };
    public enum MapSectionLoop { SHARED = 1, RED = 0, BLUE = 0, YELLOW = 0, GREEN = 0 };
    public class GameBoard
    {
        /// <summary>
        /// Array of all gameboard maps.
        /// </summary>
        public DrawableMap[] maps;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        public GameBoard()
        {
            initializeMaps();
        }

        /// <summary>
        /// Method for initializing the maps with a setup of a normal ludo map.
        /// </summary>
        private void initializeMaps()
        {
            //Instantiate map array.
            maps = new DrawableMap[5];

            //Initialize maps
            DrawableMap sharedMap = (maps[(int)MapSection.SHARED] = new DrawableMap(size: (int)MapSectionSize.SHARED, isLoopMap: true));
            DrawableMap redMap = (maps[(int)MapSection.RED] = new DrawableMap(size: (int)MapSectionSize.RED, isLoopMap: false));
            DrawableMap blueMap = (maps[(int)MapSection.BLUE] = new DrawableMap(size: (int)MapSectionSize.BLUE, isLoopMap: false));
            DrawableMap yellowMap = (maps[(int)MapSection.YELLOW] = new DrawableMap(size: (int)MapSectionSize.YELLOW, isLoopMap: false));
            DrawableMap greenMap = (maps[(int)MapSection.GREEN] = new DrawableMap(size: (int)MapSectionSize.GREEN, isLoopMap: false));

            sharedMap.Name = "SharedMap";
            redMap.Name = "RedMap";
            blueMap.Name = "BlueMap";
            yellowMap.Name = "YellowMap";
            greenMap.Name = "GreenMap";

            // Defines Team specific maps
            DrawableMap[] submaps = { redMap, blueMap, yellowMap, greenMap };
            // creates Team Special tiles on the shared map
            for (int i = 0; i < submaps.Length; i++)
            {
                int idx = i * ((int)(MapSectionSize.SHARED) / 4);
                sharedMap.SetTile(idx, new ExitTile(sharedMap, idx, submaps[i].FirstTile, (PlayerTeam)(i))); //Create exit tiles.
                sharedMap.SetTile(idx + 2, new SpawnTile(sharedMap, idx + 2, (PlayerTeam)(i))); //Create spawn tiles.
                submaps[i].LastTile = new EndTile(submaps[i], submaps[i].Tiles.Length - 1, (PlayerTeam)(i)); //Create end tiles.
            }

            
            //Set visual tile positions of the shared map
 
            //Red section
            sharedMap.SetTilePosition(46, 8, 9);
            sharedMap.SetTilePosition(47, 8, 10);
            sharedMap.SetTilePosition(48, 8, 11);
            sharedMap.SetTilePosition(49, 8, 12);
            sharedMap.SetTilePosition(50, 8, 13);
            sharedMap.SetTilePosition(51, 8, 14);

            sharedMap.SetTilePosition(0, 7, 14); //Red exit

            sharedMap.SetTilePosition(1, 6, 14);
            sharedMap.SetTilePosition(2, 6, 13);
            sharedMap.SetTilePosition(3, 6, 12);
            sharedMap.SetTilePosition(4, 6, 11);
            sharedMap.SetTilePosition(5, 6, 10);
            sharedMap.SetTilePosition(6, 6, 9);

            //Green section
            sharedMap.SetTilePosition(7, 5, 8);
            sharedMap.SetTilePosition(8, 4, 8);
            sharedMap.SetTilePosition(9, 3, 8);
            sharedMap.SetTilePosition(10, 2, 8);
            sharedMap.SetTilePosition(11, 1, 8);
            sharedMap.SetTilePosition(12, 0, 8);

            sharedMap.SetTilePosition(13, 0, 7); //Green exit

            sharedMap.SetTilePosition(14, 0, 6);
            sharedMap.SetTilePosition(15, 1, 6);
            sharedMap.SetTilePosition(16, 2, 6);
            sharedMap.SetTilePosition(17, 3, 6);
            sharedMap.SetTilePosition(18, 4, 6);
            sharedMap.SetTilePosition(19, 5, 6);

            //Yellow section
            sharedMap.SetTilePosition(20, 6, 5);
            sharedMap.SetTilePosition(21, 6, 4);
            sharedMap.SetTilePosition(22, 6, 3);
            sharedMap.SetTilePosition(23, 6, 2);
            sharedMap.SetTilePosition(24, 6, 1);
            sharedMap.SetTilePosition(25, 6, 0);

            sharedMap.SetTilePosition(26, 7, 0); //Yellow exit

            sharedMap.SetTilePosition(27, 8, 0);
            sharedMap.SetTilePosition(28, 8, 1);
            sharedMap.SetTilePosition(29, 8, 2);
            sharedMap.SetTilePosition(30, 8, 3);
            sharedMap.SetTilePosition(31, 8, 4);
            sharedMap.SetTilePosition(32, 8, 5);

            //Blue section
            sharedMap.SetTilePosition(33, 9, 6);
            sharedMap.SetTilePosition(34, 10, 6);
            sharedMap.SetTilePosition(35, 11, 6);
            sharedMap.SetTilePosition(36, 12, 6);
            sharedMap.SetTilePosition(37, 13, 6);
            sharedMap.SetTilePosition(38, 14, 6);

            sharedMap.SetTilePosition(39, 14, 7); //Blue spawn

            sharedMap.SetTilePosition(40, 14, 8);
            sharedMap.SetTilePosition(41, 13, 8);
            sharedMap.SetTilePosition(42, 12, 8);
            sharedMap.SetTilePosition(43, 11, 8);
            sharedMap.SetTilePosition(44, 10, 8);
            sharedMap.SetTilePosition(45, 9, 8);

            sharedMap.ApplyPositions();

            // Debug Code 
            Console.WriteLine(String.Join("\n", sharedMap.GetTilesInfo()));
            Array.ForEach(submaps, (map) => { Console.WriteLine(String.Join("\n", map.GetTilesInfo())); });
            Console.ReadKey();

        }

        /// <summary>
        /// Method for drawing all gameboard maps.
        /// </summary>
        public void Draw()
        {
            foreach (DrawableMap map in maps)
            {
                foreach (Tile tile in map.Tiles)
                {
                    tile.Actor.Draw();
                }
            }
        }
    }
}
