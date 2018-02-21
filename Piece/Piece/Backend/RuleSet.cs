using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludoop.Backend
{
    class RuleSet
    {
        public enum RuleIdentifier { SAFE, JUMP, RETURN, SPAWN};
        private GameBoard board;


        public RuleSet(GameBoard board)
        {
            this.board = board;
            
            
        }

        public void Rules(Piece piece, int diceValue)
        {
            foreach (RuleIdentifier rule in Enum.GetValues(typeof(RuleIdentifier)).Cast<RuleIdentifier>())
            {
                
            }
        }

        public void PieceOnTile(Tile tile, Piece piece)
        {
            
        }
    }
}
