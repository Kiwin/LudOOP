using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoop.Backend
{
    public class Dice
    {

        private int previousRoll;
        public int GetPreviousRoll()
        {
            return previousRoll;
        }
        /// <summary>
        /// Constructor for the Dice
        /// </summary>
        /// <param name="size">Defines the max value the dice can throw</param>
        public Dice(int size = 6) {
            this.Size = size;
        }

        int Size;

        // Returns a random value
        public int Roll()
        {
            int value = new Random().Next(Size);
            previousRoll = value;
            return value;
        }
    }
}
