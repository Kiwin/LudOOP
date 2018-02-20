using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    /// <summary>
    /// Interface for implementing a drawable behavior.
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Actor Getter and Setter.
        /// </summary>
        Actor Actor{
            get;
            set;
        }
    }
}
