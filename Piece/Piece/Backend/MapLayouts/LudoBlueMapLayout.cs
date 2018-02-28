using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapLayouts
{
    public class LudoBlueMapLayout : MapLayout
    {
        public LudoBlueMapLayout() {
            ///BLUE MAP
            this.Add(0, new IntVector2D(13, 7));
            this.Add(1, new IntVector2D(12, 7));
            this.Add(2, new IntVector2D(11, 7));
            this.Add(3, new IntVector2D(10, 7));
        }
    }
}
