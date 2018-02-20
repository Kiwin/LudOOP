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
            Map[] submaps = { redMap, blueMap, yellowMap, greenMap };
            // creates Team Special tiles on the shared map
            for (int i = 0; i < submaps.Length; i++)
            {
                int idx = i * ((int)(MapSectionSize.SHARED) / 4);
                sharedMap.SetTile(idx, new ExitTile(sharedMap, idx, submaps[i].FirstTile, (PlayerTeam)(i))); //Create exit tiles.
                sharedMap.SetTile(idx+1, new SpawnTile(sharedMap, idx+1, (PlayerTeam)(i))); //Create spawn tiles.
                submaps[i].LastTile = new EndTile(submaps[i], submaps[i].Tiles.Length - 1, (PlayerTeam)(i)); //Create end tiles.
            }
            
            // Debug Code 
            Console.WriteLine(String.Join("\n", sharedMap.GetTilesInfo()));
            Array.ForEach(submaps, (map) => { Console.WriteLine(String.Join("\n", map.GetTilesInfo())); });
            Console.ReadKey();

        }

        /// <summary>
        /// Method for drawing all gameboard maps.
        /// </summary>
        public void Draw() {
            foreach(DrawableMap map in maps) {
                foreach (Tile tile in map.Tiles)
                {
                    tile.Actor.Draw();
                }
            }
        }
    }
}
