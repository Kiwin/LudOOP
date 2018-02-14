﻿using Ludoop.Backend.MapBuilder;
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
                            if (rule.INTERVAL == i) {

                            }
                            break;
                        case RuleRepetitionType.EVERY:
                            if (i % rule.INTERVAL == 0)
                            {

                            }
                        break;
                    }
                }
            }
            return map;
        }
    }

}
