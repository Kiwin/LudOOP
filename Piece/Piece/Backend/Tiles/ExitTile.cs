using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.Tiles
{
    public class ExitTile : Tile
    {

        public ExitTile(int x, int y, Tile nextMapEntryTile) : base(x, y, TileType.EXIT)
        {
            this.nextMapEntryTile = nextMapEntryTile;
        }

        private Tile nextMapEntryTile;
        public Tile NextMapEntryTile
        {
            get { return this.nextMapEntryTile; }
            set { this.nextMapEntryTile = value; }
        }

    }
}
