using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public enum PieceType { CIRCLE, SQUARE, TRIANGLE, PENTAGON };

    public interface IPiece : IMove
    {
        PieceType Type { get; set; }
    }
}
