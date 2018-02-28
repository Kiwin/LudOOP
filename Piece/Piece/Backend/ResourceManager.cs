using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ludoop.Backend
{
    static class ResourceManager
    {

        /// <summary>
        /// Contains the Ludo Board class
        /// </summary>
        private static LudoGameBoard board;

        
        public static LudoGameBoard Board
        {
            get { return board; }
            set { board = value; }
        }

        // TODO: Loop through all players and add them all and get pieces for them all.
        // TODO: Build GameBoard from this function as well with all rules implemented.
        // Gameboard is kiwins new method of handling the map 

        /// <summary>
        /// Initializes the resources
        /// </summary>
        /// <param name="piecesPerPlayer">the amount of pieces every player is able to have</param>
        public static void Initialize(int piecesPerPlayer)
        {
            // assigns every players piecebuffer with the correct amount of pieces
            for (int i = 0; i <= players.Count; i++)
            {
                players[i].PieceBuffer = piecesPerPlayer;
            }
        }

        /// <summary>
        /// Contains all players in the game
        /// </summary>
        private static List<Player> players;

        /// <summary>
        /// Gets all the players in the game
        /// </summary>
        /// <returns>returns List<Player></returns>
        public static List<Player> GetPlayers()
        {
            return players;
        }

        /// <summary>
        /// Adds a new player to the game
        /// </summary>
        /// <param name="player">Player object containing the new player</param>
        public static void AddPlayer(Player player)
        {
            players.Add(player);
        }

        /// <summary>
        ///  Removes a specific player from the game (needs to be the same or an exact copy of the object)
        /// </summary>
        /// <param name="player">the player to be removed</param>
        public static void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        /// <summary>
        /// Removes a specific player from their name
        /// </summary>
        /// <param name="name">the name of the player</param>
        public static void RemovePlayer(string name)
        {
            // loops through all players and finds the first with the same name as the parameter and then removes it
            Player player = players.Find(cur => cur.Name == name);
            if (player != null)
            {
                players.Remove(player);
            }
        }
    }
}
