using Ludoop.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop
{
    /// <summary>
    /// Class representing a player.
    /// </summary>
    public class Player : IPlayer
    {

        private string name;

        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
