using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoLudo.View;

namespace PseudoLudo.Backend.Tiles
{
    class DefaultTile : Tile
    {
        public DefaultTile(Map map, int index) : base(TileType.DEFAULT, map, index) {}

        public override Actor Actor { get; set; }
    }
}
