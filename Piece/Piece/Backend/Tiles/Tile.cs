using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    public abstract class Tile : ITile
    {

        public Tile(TileType type, Map map)
        {
            this.Type = type;
            this.NextTile = this;
            this.PrevTile = this;
        }

        private Map map;
        public Map Map
        {
            get { return this.map; }
            set { this.map = value; }
        }

        private Tile prevTile;
        public Tile PrevTile
        {
            get { return this.prevTile; }
            set { this.prevTile = value; }
        }

        private Tile nextTile;
        public Tile NextTile
        {
            get { return this.nextTile; }
            set { this.nextTile = value; }
        }

        private TileType type;

        /// <summary>
        /// get and set, type of tile
        /// </summary>
        public TileType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public event EventHandler OnStep;
        public event EventHandler OnStepEnd;

    }
}
