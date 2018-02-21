using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class DrawableMap : Map
    {
        /// <summary>
        /// Array containing the positions of the map's tiles.
        /// </summary>
        public IntVector2D[] TilePositions;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="isLoopMap"></param>
        public DrawableMap(int size, bool isLoopMap) : base(size, isLoopMap)
        {
            TilePositions = new IntVector2D[size];
            for (int i = 0; i < size; i++) {
                TilePositions[i] = new IntVector2D();
            }
        }

        /// <summary>
        /// Method for applying changes in the TilePositions array to the map tiles' actors.
        /// </summary>
        public void ApplyPositions() {
            for (int i = 0; i < Tiles.Length; i++) {
                Tiles[i].Actor.X = TilePositions[i].X;
                Tiles[i].Actor.Y = TilePositions[i].Y;
            }
        }
    }
}
