using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    class Tile : ITile
    {
        public Tile(int x, int y, TileType type)
        {
            this.Position = new Vector2D(x, y);
        }

        private Vector2D position;
        /// <summary>
        /// get and set, position for object
        /// </summary>
        public Vector2D Position
        {
            get { return this.position; }
            set { this.position = value; }
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
