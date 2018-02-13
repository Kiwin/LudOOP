using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    interface IPosition
    {
        /// <summary>
        /// Defines the position of the object
        /// </summary>
        Vector2D Position
        {
            get;
            set;
        }
        
    }
}
