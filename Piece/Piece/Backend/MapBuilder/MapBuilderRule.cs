using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public enum RuleRepetitionMode { FIRST, EVERY};

    public class MapBuilderRule
    {
        public MapBuilderRule(TileType tileType, RuleRepetitionMode repeatType, int interval = 1, int intervalOffset = 0)
        {
            this.TILE_TYPE = tileType;
            this.REPEAT_TYPE = repeatType;
            this.INTERVAL = interval;
            this.INTERVAL_OFFSET = intervalOffset;
        }

        public readonly TileType TILE_TYPE;
        public readonly RuleRepetitionMode REPEAT_TYPE;
        public readonly int INTERVAL;
        public readonly int INTERVAL_OFFSET;

    }
}
