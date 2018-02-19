using Ludoop.Backend;
using Ludoop.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public abstract class Tile : IDraw
    {
        public readonly TileType TYPE;
        public Map Map;
        public Tile NextTile;
        public Tile PrevTile;
        public int Index;

        public Tile(TileType type, Map map, int index)
        {
            this.TYPE = type;
            this.Map = map;
            this.Index = index;
            this.NextTile = this;
            this.PrevTile = this;
        }

        virtual public void onPieceLeave(Piece piece, bool isForward, bool isLast)
        {
            piece.CurrentTile = this.NextTile;
        }
        virtual public void onPieceEnter(Piece piece, bool isForward, bool isLast) { }
        public abstract Actor actor { get; set; }
    }
}
