using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// Class representing a 2D integer-precise vector.
    /// </summary>
    public class Vector2D
    {
        /// <summary>
        /// Constructor for Vector2D takes a map index and a tile index to specify position
        /// </summary>
        /// <param name="x">Tile Index</param>
        /// <param name="y">Map Index</param>
        public Vector2D(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        private int x, y;

        /// <summary>
        /// get and set for map index 
        /// </summary>
        public int X
        {
            get { return x; }
            set { this.x = value; }
        }
        
        /// <summary>
        /// get and set for tile index
        /// </summary>
        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }

        /// <summary>
        /// clones the current object
        /// </summary>
        /// <returns>returns a Vector2D identical to the original object</returns>
        public Vector2D Clone()
        {
            return new Vector2D(this.X, this.Y);
        }

    }
}
