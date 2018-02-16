using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoLudo.View;

namespace PseudoLudo.Backend
{

    public enum TileType { DEFAULT, SPAWN, STAR, GLOBE, EXIT, END};

    public abstract class Tile : IDraw
    {
        public readonly TileType TYPE;
        public Map Map;
        public Tile NextTile;
        public Tile PrevTile;
        public int Index;

        public Tile(TileType type, Map map, int index) {
            this.TYPE = type;
            this.Map = map;
            this.Index = index;
            this.NextTile = this;
            this.PrevTile = this;
        }

        virtual public void onPieceLeave(Piece piece, bool isForward, bool isLast) {
            piece.CurrentTile = this.NextTile;
        }
        virtual public void onPieceEnter(Piece piece, bool isForward, bool isLast) { }
        public abstract Actor Actor { get; set; }
    }
}
