using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend.MapLayouts
{
    public class LudoSharedMapLayout : MapLayout
    {
        public LudoSharedMapLayout() {
            //Red section
            this.Add(46, new IntVector2D(8, 9));
            this.Add(47, new IntVector2D(8, 10));
            this.Add(48, new IntVector2D(8, 11));
            this.Add(49, new IntVector2D(8, 12));
            this.Add(50, new IntVector2D(8, 13));
            this.Add(51, new IntVector2D(8, 14));

            this.Add(0, new IntVector2D(7, 14)); //Red exit

            this.Add(1, new IntVector2D(6, 14));
            this.Add(2, new IntVector2D(6, 13));
            this.Add(3, new IntVector2D(6, 12));
            this.Add(4, new IntVector2D(6, 11));
            this.Add(5, new IntVector2D(6, 10));
            this.Add(6, new IntVector2D(6, 9));

            //Green section
            this.Add(7, new IntVector2D(5, 8));
            this.Add(8, new IntVector2D(4, 8));
            this.Add(9, new IntVector2D(3, 8));
            this.Add(10, new IntVector2D(2, 8));
            this.Add(11, new IntVector2D(1, 8));
            this.Add(12, new IntVector2D(0, 8));

            this.Add(13, new IntVector2D(0, 7)); //Green exit

            this.Add(14, new IntVector2D(0, 6));
            this.Add(15, new IntVector2D(1, 6));
            this.Add(16, new IntVector2D(2, 6));
            this.Add(17, new IntVector2D(3, 6));
            this.Add(18, new IntVector2D(4, 6));
            this.Add(19, new IntVector2D(5, 6));

            //Yellow section
            this.Add(20, new IntVector2D(6, 5));
            this.Add(21, new IntVector2D(6, 4));
            this.Add(22, new IntVector2D(6, 3));
            this.Add(23, new IntVector2D(6, 2));
            this.Add(24, new IntVector2D(6, 1));
            this.Add(25, new IntVector2D(6, 0));

            this.Add(26, new IntVector2D(7, 0)); //Yellow exit

            this.Add(27, new IntVector2D(8, 0));
            this.Add(28, new IntVector2D(8, 1));
            this.Add(29, new IntVector2D(8, 2));
            this.Add(30, new IntVector2D(8, 3));
            this.Add(31, new IntVector2D(8, 4));
            this.Add(32, new IntVector2D(8, 5));

            //Blue section
            this.Add(33, new IntVector2D(9, 6));
            this.Add(34, new IntVector2D(10, 6));
            this.Add(35, new IntVector2D(11, 6));
            this.Add(36, new IntVector2D(12, 6));
            this.Add(37, new IntVector2D(13, 6));
            this.Add(38, new IntVector2D(14, 6));

            this.Add(39, new IntVector2D(14, 7)); //Blue spawn

            this.Add(40, new IntVector2D(14, 8));
            this.Add(41, new IntVector2D(13, 8));
            this.Add(42, new IntVector2D(12, 8));
            this.Add(43, new IntVector2D(11, 8));
            this.Add(44, new IntVector2D(10, 8));
            this.Add(45, new IntVector2D(9, 8));
        }
    }
}
