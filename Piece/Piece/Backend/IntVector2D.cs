using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    public class IntVector2D
    {
        public int X, Y;

        /// <summary>
        /// Constructor for the IntVector2D
        /// </summary>
        /// <param name="x">Defines </param>
        /// <param name="y"></param>
        public IntVector2D(int x = 0, int y = 0) {
            this.X = x;
            this.Y = y;
        }
        public IntVector2D add(IntVector2D other) {
            this.X += other.X;
            this.Y += other.Y;
            return this;
        }
        public IntVector2D sub(IntVector2D other)
        {
            this.X -= other.X;
            this.Y -= other.Y;
            return this;
        }
        public IntVector2D div(IntVector2D other)
        {
            this.X /= other.X;
            this.Y /= other.Y;
            return this;
        }
        public IntVector2D mult(IntVector2D other)
        {
            this.X *= other.X;
            this.Y *= other.Y;
            return this;
        }
        public bool Match(IntVector2D other) {
            return this.X == other.X && this.Y == other.Y;
        }
        public IntVector2D Clone() {
            return new IntVector2D(this.X, this.Y);
        }
    }
}
