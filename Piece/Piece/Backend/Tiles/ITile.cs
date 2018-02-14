using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// types of Tiles on board
    /// </summary>
    public enum TileType { DEFAULT, GLOBE, STAR, SPAWNPOINT, EXIT, END};
    
    interface ITile : IPosition
    {

        TileType Type {
            get;
            set;
        }

        event EventHandler OnStep;

        event EventHandler OnStepEnd;
    }
}
