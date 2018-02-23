using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.Tiles
{
    /// <summary>
    /// types of Tiles on board
    /// </summary>
    public enum TileType { DEFAULT, GLOBE, STAR, SPAWNPOINT, EXIT, END};
    
    public interface ITile
    {

        TileType Type {
            get;
            set;
        }

    }
}
