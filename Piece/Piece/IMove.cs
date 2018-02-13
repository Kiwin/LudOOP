using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// Interface for moving objects around and between maps.
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// Move a specified amount of tiles.
        /// </summary>
        /// <param name="tiles">Amount of tiles to move (Negative amount for backwards).</param>
        void Move(int tiles);

        /// <summary>
        /// Move to a specified tile.
        /// </summary>
        /// <param name="tileIndex">Tile Index</param>
        void MoveTo(int tileIndex);

        /// <summary>
        /// Move to a specified map and a specified tile.
        /// </summary>
        /// <param name="mapIndex">Map index</param>
        /// <param name="tileIndex">Tile index</param>
        void MoveToMap(int mapIndex, int tileIndex);
    }
}
