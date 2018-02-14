using Ludoop.Backend.MapBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapBuilder
{
    public abstract class MapBuilder
    {

        protected List<MapBuilderRule> rules;

        public MapBuilder()
        {
            rules = new List<MapBuilderRule>();
        }

        /// <summary>
        /// Method for adding rules that indicate what types tiles should be.
        /// </summary>
        /// <param name="rule">MapBuilderRule to add</param>
        public void AddRule(MapBuilderRule rule)
        {
            rules.Add(rule);
        }

        public void ClearRules() {
            rules.Clear();
        }

        /// <summary>
        /// Method should generating a map based on applied rules.
        /// </summary>
        /// <param name="mapSize">Size of the map.</param>
        /// <returns></returns>
        public abstract Map GenerateMap(int mapSize);

    }

    public class NormalMapBuilder : MapBuilder
    {

        public NormalMapBuilder()
        {

        }

        public override Map GenerateMap(int mapSize)
        {
            Map map = new Map(mapSize);
            for (int i = 0; i < mapSize; i++)
            {
                foreach (MapBuilderRule rule in rules)
                {
                    switch (rule.REPEAT_TYPE)
                    {
                        case RuleRepetitionType.FIRST:
                            if (rule.INTERVAL == i)
                            {
                                map.Tiles[i] = new Tile(rule.TILE_TYPE);
                                break;
                            }
                            break;
                        case RuleRepetitionType.EVERY:
                            if (i % rule.INTERVAL == 0)
                            {
                                map.Tiles[i] = new Tile(rule.TILE_TYPE);
                                break;
                            }
                            break;
                    }
                }
                if (map.Tiles[i] == null)
                {
                    map.Tiles[i] = new Tile(TileType.DEFAULT);
                }
            }
            return map;
        }
    }

}
