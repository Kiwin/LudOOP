using Ludoop.Backend;
using Ludoop.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.Tiles
{

    // Base class for tiles
    public abstract class Tile : IDraw
    {
        public readonly TileType TYPE;
        public Map Map;
        public Tile NextTile;
        public Tile PrevTile;
        public int Index;

        /// <summary>
        /// Constructor for the Tiletype
        /// </summary>
        /// <param name="type">the type of the tile defined in ITile</param>
        /// <param name="map">defines the Map the tile is on</param>
        /// <param name="index">Defines the index the tile is on</param>
        public Tile(TileType type, Map map, int index)
        {
            this.TYPE = type;
            this.Map = map;
            this.Index = index;
            this.NextTile = this;
            this.PrevTile = this;
        }

        /// <summary>
        /// when a piece leaves the current tile the piece changes its current tile to the next tile (steps the tile once over) 
        /// </summary>
        /// <param name="piece">the piece in question</param>
        /// <param name="isForward">is the piece moving forward?</param>
        /// <param name="isLast">Is the current step the last </param>
        virtual public void onPieceLeave(Piece piece, bool isForward, bool isLast)
        {
            piece.CurrentTile = this.NextTile;
        }

        public virtual Tile GetNextTile(Piece piece)
        {
            return this.NextTile;
        }

        public virtual Tile GetPrevousTile(Piece piece)
        {
            return this.PrevTile;
        }


        /// <summary>
        /// runs when the piece enters a tile
        /// </summary>
        /// <param name="piece">the piece in question</param>
        /// <param name="isForward">is the piece moving forward?</param>
        /// <param name="isLast">Is the current step the last </param>
        virtual public void onPieceEnter(Piece piece, bool isForward, bool isLast) { }
        public abstract Actor Actor { get; set; }
    }
}