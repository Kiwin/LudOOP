using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    // Game Implements general game flow and handles how the game works
    public class Game
    {
        private ResourceManager resources = new ResourceManager();
        private PlayerTeam CurrentPlayer;

        /// <summary>
        /// Initializes the Game Class
        /// </summary>
        /// <param name="players">Defines the Player classes to be added</param>
        /// <param name="piecesPerPlayer"> defines the amount of pieces per player</param>
        public Game(Player[] players, int piecesPerPlayer)
        {
            for (int i = 0; i <= players.Length; i++)
            {
                resources.AddPlayer(players[i]);
            }


            resources.Initialize(piecesPerPlayer);
            resources.Board = new GameBoard();
        }
        
        
        
        



    }
}

                


