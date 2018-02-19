using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    /// <summary>
    /// types of Tiles on board
    /// </summary>
    public enum TileType { DEFAULT, GLOBE, STAR, SPAWNPOINT, EXIT, END};
    
    interface ITile
    {

        TileType Type {
            get;
            set;
        }

    }
}
