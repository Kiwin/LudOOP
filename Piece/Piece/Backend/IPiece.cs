using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    interface IPiece : IMove
    {

        event EventHandler OnStep;

        event EventHandler OnStepEnd;
    }
}
