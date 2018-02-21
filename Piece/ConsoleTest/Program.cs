using System;
using Ludoop;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Piece piece = new Piece(Ludoop.Backend.PlayerTeam.BLUE, PieceShape.CIRCLE, Tile);

            piece.Move(4);

            Console.WriteLine(string.Format("X: {0} {1}Y: {2}", piece.Position.X, Environment.NewLine, piece.Position.Y));
            Console.ReadLine();
        }
    }
}
