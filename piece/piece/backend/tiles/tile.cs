using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    public class Tile : ITile
    {
        public Tile(TileType type)
        {
            this.Type = type;
            this.NextTile = this;
            this.PrevTile = this;
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

        /*
        private Vector2D position;
        /// <summary>
        /// get and set, position for object
        /// </summary>
        public Vector2D Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        */

        private TileType type;

        /// <summary>
        /// get and set, type of tile
        /// </summary>
        public TileType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        

    }
}
