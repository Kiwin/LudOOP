using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class Map
    {
        public Map(int size) {
            tiles = new Tile[size];
        }

        public Tile[] tiles;
        public Tile[] Tiles {
            get { return this.tiles; }
            set { this.tiles = value; }
        }


    }
}
