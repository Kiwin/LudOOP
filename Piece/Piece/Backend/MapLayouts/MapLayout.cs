using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public class MapLayout : Dictionary<int, IntVector2D>
    {
        
        public MapLayout() {

        }

        public void ApplyLayout(Map map) {
            foreach (KeyValuePair<int, IntVector2D> pair in this) {
                map.Tiles[pair.Key].Actor.X = pair.Value.X;
                map.Tiles[pair.Key].Actor.Y = pair.Value.Y;
            }
        }
    }
}
