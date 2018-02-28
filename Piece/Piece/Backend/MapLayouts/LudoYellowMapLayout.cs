using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapLayouts
{
    public class LudoYellowMapLayout : MapLayout
    {
        public LudoYellowMapLayout() {
            ///YELLOW MAP
            this.Add(0, new IntVector2D(7, 1));
            this.Add(1, new IntVector2D(7, 2));
            this.Add(2, new IntVector2D(7, 3));
            this.Add(3, new IntVector2D(7, 4));
        }
    }
}
