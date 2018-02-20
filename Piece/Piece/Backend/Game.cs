using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    // Game Implements general game flow and handles how the game works INCOMPLETE
    public class Game
    {
        private ResourceManager resources = new ResourceManager();
        private Player CurrentPlayer;
        private Dice Die;

        /// <summary>
        /// Initializes the Game Class
        /// </summary>
        /// <param name="players">Defines the Player classes to be added</param>
        /// <param name="piecesPerPlayer"> defines the amount of pieces per player</param>
        public Game(Player[] players, int piecesPerPlayer, int sizeOfDie)
        {
            for (int i = 0; i <= players.Length; i++)
            {
                resources.AddPlayer(players[i]);
            }

            Die = new Dice(sizeOfDie);
            resources.Initialize(piecesPerPlayer);
            resources.Board = new GameBoard();
        }

        public void NextTurn()
        {
            int currentPlayerIndex = resources.GetPlayers().IndexOf(CurrentPlayer);

            if (currentPlayerIndex >= resources.GetPlayers().Count)
            {
                CurrentPlayer = resources.GetPlayers().First();
            } else
            {
                CurrentPlayer = resources.GetPlayers()[currentPlayerIndex + 1];
            }
        }

        public void DetermineFirstPlayer()
        {
            int LargestValue = 0;
            Player luckiestPlayer = resources.GetPlayers().First();

            for (int i = 0; i < resources.GetPlayers().Count; i++)
            {
                Player curPlayer = resources.GetPlayers()[i];

                int roll = Die.Roll();

                if (roll > LargestValue)
                {
                    LargestValue = roll;
                    luckiestPlayer = curPlayer;
                }
            }

            CurrentPlayer = luckiestPlayer;
        }
    }
}

                


