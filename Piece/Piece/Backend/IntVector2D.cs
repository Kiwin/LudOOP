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
        /// Class Constructor.
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public IntVector2D(int x = 0, int y = 0) {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Method for adding two integer vectors.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IntVector2D add(IntVector2D other) {
            this.X += other.X;
            this.Y += other.Y;
            return this;
        }

        /// <summary>
        /// Method for subtracting two integer vectors.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IntVector2D sub(IntVector2D other)
        {
            this.X -= other.X;
            this.Y -= other.Y;
            return this;
        }

        /// <summary>
        /// Method for dividing two integer vectors.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IntVector2D div(IntVector2D other)
        {
            this.X /= other.X;
            this.Y /= other.Y;
            return this;
        }

        /// <summary>
        /// Method for multiplying two integer vectors.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IntVector2D mult(IntVector2D other)
        {
            this.X *= other.X;
            this.Y *= other.Y;
            return this;
        }

        /// <summary>
        /// Method for checking if two vectors coordinates match.
        /// </summary>
        /// <param name="other">Vector to match with.</param>
        /// <returns>Returns if THIS vector's coordinates matches OTHER vector's coordinates.</returns>
        public bool Match(IntVector2D other) {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <summary>
        /// Clones the current object
        /// </summary>
        /// <returns>Returns a IntVector2D identical to the original object</returns>
        public IntVector2D Clone() {
            return new IntVector2D(this.X, this.Y);
        }
    }
}
