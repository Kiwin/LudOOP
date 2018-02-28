using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapLayouts
{
    public class LudoGreenMapLayout : MapLayout
    {
        public LudoGreenMapLayout() {
            ///GREEN MAP
            this.Add(0, new IntVector2D(1, 7));
            this.Add(1, new IntVector2D(2, 7));
            this.Add(2, new IntVector2D(3, 7));
            this.Add(3, new IntVector2D(4, 7));
        }
    }
}
