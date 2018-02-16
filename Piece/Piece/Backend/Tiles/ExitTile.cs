using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.Tiles
{
    public class ExitTile : Tile, ITeam
    {

        private PlayerTeam team;

        public ExitTile(Map map, Tile nextMapEntryTile) : base(TileType.EXIT, map)
        {
            this.nextMapEntryTile = nextMapEntryTile;
        }

        private Tile nextMapEntryTile;
        public Tile NextMapEntryTile
        {
            get { return this.nextMapEntryTile; }
            set { this.nextMapEntryTile = value; }
        }

        public PlayerTeam Team
        {
            get { return this.team; }
            set { this.team = value; }
        }
    }
}