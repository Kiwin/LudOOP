using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    interface IPosition
    {
        /// <summary>
        /// Defines the position of the object 
        /// CURRENTLY DEPRECATED DUE TO A REWORK OF THE GENERAL LOCATION BASED PIECES
        /// </summary>
        IntVector2D Position
        {
            get;
            set;
        }
        
    }
}
