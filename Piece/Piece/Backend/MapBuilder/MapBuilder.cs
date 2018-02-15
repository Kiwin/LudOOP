using Ludoop.Backend.MapBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapBuilder
{
    /// <summary>
    /// Abstract Class representing a map builder.
    /// </summary>
    public abstract class MapBuilder
    {

        //List of rules objects.
        protected List<MapBuilderRule> rules;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MapBuilder()
        {
            rules = new List<MapBuilderRule>();
        }

        /// <summary>
        /// Method for adding rules that indicate what types tiles should be added.
        /// </summary>
        /// <param name="rule">MapBuilderRule to add</param>
        public void AddRule(MapBuilderRule rule)
        {
            rules.Add(rule);
        }

        public void ClearRules()
        {
            rules.Clear();
        }

        /// <summary>
        /// Method should generating a map based on applied rules.
        /// </summary>
        /// <param name="mapSize">Size of the map.</param>
        /// <returns></returns>
        public abstract Map GenerateMap(int mapSize);

    }

    /// <summary>
    /// Class representing a basic map builder.
    /// </summary>
    public class NormalMapBuilder : MapBuilder
    {

        private TileType defaultTileType;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="defaultTileType">TileType to fill in when no rule is applies</param>
        public NormalMapBuilder(TileType defaultTileType = TileType.DEFAULT)
        {
            this.defaultTileType = defaultTileType;
        }

        /// <summary>
        /// Method generates a map based on applied rules.
        /// </summary>
        /// <param name="mapSize">Size of the to be generated map.</param>
        /// <returns></returns>
        public override Map GenerateMap(int mapSize)
        {
            Map map = new Map(mapSize); //Instantiate map object.
            for (int i = 0; i < mapSize; i++) //Loop through tiles.
            {
                foreach (MapBuilderRule rule in rules) //Loop through rules.
                {
                    switch (rule.REPEAT_TYPE)
                    {
                        //If rule should apply only first time 'i' hits interval.
                        case RuleRepetitionMode.FIRST:
                            if (rule.INTERVAL == i-rule.INTERVAL_OFFSET) //Check if rule should apply this iteration.
                            {
                                map.Tiles[i] = new Tile(rule.TILE_TYPE); //Create new tile
                                break; //Break out of looping though rules and continue to next tile.
                            }
                            break;
                        //If rule should apply every time 'i' hits interval.
                        case RuleRepetitionMode.EVERY:
                            if ((i - rule.INTERVAL_OFFSET) % rule.INTERVAL == 0) //Check if rule should apply this iteration.
                            {
                                map.Tiles[i] = new Tile(rule.TILE_TYPE); //Create new tile
                                break; //Break out of looping though rules and continue to next tile.
                            }
                            break;
                    }
                }
                if (map.Tiles[i] == null) //If no rule were triggered
                {
                    map.Tiles[i] = new Tile(defaultTileType); //Set tile to a default tile.
                }

                if (i == mapSize - 1) //Assign previous and next tile.
                {
                    map.Tiles[i].PrevTile = map.Tiles[0];
                    map.Tiles[i].PrevTile.NextTile = map.Tiles[i];
                }
                else if (i > 0) //Assign previous and next tile for last and first tile.
                {
                    map.Tiles[i].PrevTile = map.Tiles[i - 1];
                    map.Tiles[i].PrevTile.NextTile = map.Tiles[i];
                }
            }
            return map; //Return the map.
        }
    }

}
