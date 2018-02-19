using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoLudo.Backend
{
    public class Dice
    {

        public Dice(int size = 6) {
            this.Size = size;
        }

        int Size;

        public int Roll() {
            return new Random().Next(Size);
        }
    }
}
