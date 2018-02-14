using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapBuilder
{
    public enum RuleRepetitionType { FIRST, EVERY};

    public class MapBuilderRule
    {
        public MapBuilderRule(TileType tileType, RuleRepetitionType repeatType, int interval)
        {
            this.TILE_TYPE = tileType;
            this.REPEAT_TYPE = repeatType;
            this.INTERVAL = interval;
        }

        public readonly TileType TILE_TYPE;
        public readonly RuleRepetitionType REPEAT_TYPE;
        public readonly int INTERVAL;

    }
}
