using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// Interface for identifying and setting the owner of an object.
    /// </summary>
    public interface IOwned
    {
        Player Owner {
            get;
            set;
        }
    }
}
