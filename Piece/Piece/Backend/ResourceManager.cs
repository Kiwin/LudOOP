using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ludoop.Backend.Tiles
{
    class ResourceManager
    {
        private GameBoard board;

        public GameBoard Board
        {
            get { return board; }
            set { this.board = value; }
        }

        // TODO: Loop through all players and add them all and get pieces for them all.
        // TODO: Build GameBoard from this function as well with all rules implemented.
        // Gameboard is kiwins new method of handling the map 
        private void Initialize(Player[] players, int piecesPerPlayer)
        {
            for (int i = 0; i <= players.Length; i++)
            {
                players[i].PieceBuffer = piecesPerPlayer;
            }
        }

        private List<Player> players;

        private List<Player> GetPlayers()
        {
            return players;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }
        
        public void RemovePlayer(string name)
        {
            Player player = players.Find(cur => cur.Name == name);
            players.Remove(player);
        }
    }
}
