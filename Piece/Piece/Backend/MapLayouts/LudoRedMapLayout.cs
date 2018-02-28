using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapLayouts
{
    public class LudoRedMapLayout : MapLayout
    {
        public LudoRedMapLayout() {
            ///RED MAP
            this.Add(0, new IntVector2D(7, 13));
            this.Add(1, new IntVector2D(7, 12));
            this.Add(2, new IntVector2D(7, 11));
            this.Add(3, new IntVector2D(7, 10));
        }
    }
}
