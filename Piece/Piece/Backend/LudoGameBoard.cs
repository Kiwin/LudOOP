using Ludoop.Backend.MapLayouts;
using Ludoop.Backend.Tiles;
using Ludoop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    public enum MapSection { SHARED = 0, RED, GREEN, BLUE, YELLOW };
    public enum MapSectionSize { SHARED = 52, RED = 4, BLUE = 4, YELLOW = 4, GREEN = 4 };
    public enum MapSectionLoop { SHARED = 1, RED = 0, BLUE = 0, YELLOW = 0, GREEN = 0 };

    public class LudoGameBoard : IDraw2D
    {
        /// <summary>
        /// Array of all gameboard maps.
        /// </summary>
        public Map[] Maps;
        private Map sharedMap, redMap, blueMap, yellowMap, greenMap;
        private MapLayout sharedMapLayout, redMapLayout, blueMapLayout, yellowMapLayout, greenMapLayout;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        public LudoGameBoard()
        {
            initializeMaps();
            initializeLayouts();
            applyLayouts();
        }

        /// <summary>
        /// Method for initializing the maps with a setup of a normal ludo map.
        /// </summary>
        /// 
        private void initializeMaps()
        {
            //Instantiate map array.
            Maps = new Map[5];

            //Initialize maps
            sharedMap = (Maps[(int)MapSection.SHARED] = new Map(size: (int)MapSectionSize.SHARED, isLoopMap: true));
            redMap = (Maps[(int)MapSection.RED] = new Map(size: (int)MapSectionSize.RED, isLoopMap: false));
            blueMap = (Maps[(int)MapSection.BLUE] = new Map(size: (int)MapSectionSize.BLUE, isLoopMap: false));
            yellowMap = (Maps[(int)MapSection.YELLOW] = new Map(size: (int)MapSectionSize.YELLOW, isLoopMap: false));
            greenMap = (Maps[(int)MapSection.GREEN] = new Map(size: (int)MapSectionSize.GREEN, isLoopMap: false));

            sharedMap.Name = "SharedMap";
            redMap.Name = "RedMap";
            blueMap.Name = "BlueMap";
            yellowMap.Name = "YellowMap";
            greenMap.Name = "GreenMap";

            // Defines Team specific maps
            Map[] submaps = { redMap, greenMap, yellowMap, blueMap };

            // creates Team Special tiles on the shared map
            for (int i = 0; i < submaps.Length; i++)
            {
                int idx = i * ((int)(MapSectionSize.SHARED) / 4);

                Tile newTile = new ExitTile(sharedMap, idx, submaps[i].FirstTile, (PlayerTeam)(i));
                sharedMap.SetTile(idx, newTile); //Create exit tiles.

                newTile = new SpawnTile(sharedMap, idx + 2, (PlayerTeam)(i));
                sharedMap.SetTile(idx + 2, newTile); //Create spawn tiles.

                newTile = new EndTile(submaps[i], submaps[i].Tiles.Length - 1, (PlayerTeam)(i));
                submaps[i].LastTile = newTile; //Create end tiles.
            }

            // Set tile actors
            foreach (Map map in Maps)
            {
                foreach (Tile tile in map.Tiles)
                {
                    tile.Actor = new ConsoleTileActor(Game.GetConsoleRenderConfig(), tile);
                }
            }
        }

        /// <summary>
        /// Method for instanciating layouts of a normal ludo map.
        /// </summary>
        private void initializeLayouts()
        {
            sharedMapLayout = new LudoSharedMapLayout();
            redMapLayout = new LudoRedMapLayout();
            blueMapLayout = new LudoBlueMapLayout();
            yellowMapLayout = new LudoYellowMapLayout();
            greenMapLayout = new LudoGreenMapLayout();
        }

        /// <summary>
        /// Method for applying the maplayouts to the maps.
        /// </summary>
        private void applyLayouts()
        {
            sharedMapLayout.ApplyLayout(sharedMap);
            redMapLayout.ApplyLayout(redMap);
            blueMapLayout.ApplyLayout(blueMap);
            yellowMapLayout.ApplyLayout(yellowMap);
            greenMapLayout.ApplyLayout(greenMap);
        }

        public void Debug()
        {
            // Debug Code 
            Array.ForEach(Maps, (map) => { Console.WriteLine(String.Join("\n", map.GetTilesInfo())); });
        }

        /// <summary>
        /// Method for drawing all gameboard maps.
        /// </summary>

        public void Draw(float x = 0, float y = 0, float w = 20, float h = 20)
        {
            var renderConfig = Game.GetConsoleRenderConfig();
            renderConfig.RowOffset = (int)x;
            renderConfig.ColumnScale = (int)y;
            renderConfig.RowScale = (int)w;
            renderConfig.ColumnScale = (int)h;

            foreach (Map map in Maps)
            {
                foreach (Tile tile in map.Tiles)
                {
                    tile.Actor.Draw();
                }
            }
        }
    }
}
