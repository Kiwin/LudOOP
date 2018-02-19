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
        public abstract void Draw(float x, float y, float w, float h);

    }
}
