using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    /// <summary>
    /// Interface for implementing a drawable behavior.
    /// </summary>
    public interface IDraw2D
    {
        void Draw(float x, float y, float w, float h);
    }
}
