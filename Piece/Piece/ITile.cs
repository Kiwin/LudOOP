using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// types of Tiles on board
    /// </summary>
    public enum TileType { DEFAULT, GLOBE, STAR, SPAWNPOINT};
    
    interface ITile
    {
        //void OnStep(/*Piece Trigger*/);

        event EventHandler OnStep;

        event EventHandler OnStepEnd;
    }
}
