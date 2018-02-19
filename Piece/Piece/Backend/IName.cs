using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    /// <summary>
    /// Interface for naming an object.
    /// </summary>
    public interface IName
    {
        #region Getters and Setters
        string Name {
            get;
            set;
        }
        #endregion
    }
}
