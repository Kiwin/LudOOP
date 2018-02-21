using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ludoop;
using System;

namespace Piece_movement
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MovePiece()
        {
            Piece piece = new Piece(TeamColor.BLUE, PieceShape.CIRCLE, 0, 0);
            
        }
    }
}
