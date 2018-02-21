using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    public class Vector2D
    {

        public Vector2D(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        private int x, y;

        public int X
        {
            get { return x; }
            set { this.x = value; }
        }
        
        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }

        public Vector2D Clone()
        {
            return new Vector2D(this.X, this.Y);
        }

    }
}
