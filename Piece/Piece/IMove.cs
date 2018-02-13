using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    public interface IMove
    {
        void Move(int tiles);
        void MoveTo(int tileIndex);
        void MoveToMap(int mapIndex, int tileIndex);
    }
}
