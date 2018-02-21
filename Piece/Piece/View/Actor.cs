using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    /// <summary>
    /// Abstract class representing a drawable object.
    /// </summary>
    public abstract class Actor
    {
        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="x">Actor's X-Position.</param>
        /// <param name="y">Actor's Y-Position.</param>
        /// <param name="w">Actor's Width.</param>
        /// <param name="h">Actor's Height.</param>
        public Actor(float x = 0, float y = 0, float w = 0, float h = 0) { }

        public float X, Y, Width, Height;

        /// <summary>
        /// Method for drawing actor using it's own members.
        /// </summary>
        public void Draw()
        {
            Draw(this.X, this.Y, this.Width, this.Height);
        }

        /// <summary>
        /// Method for drawing actor.
        /// </summary>
        public abstract void Draw(float x, float y, float w, float h);
    }
}
