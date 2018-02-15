using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ludoop.Backend.Tiles
{
    class GameManager
    {

        private Map map;

        public Map Map
        {
            get { return map; }
            set { this.map = value; }
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
