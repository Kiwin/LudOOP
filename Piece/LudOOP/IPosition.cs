using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    interface IPosition
    {
        Vector2D GetPosition();

        void SetPostion(int x, int y);
    }
}
