using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoLudo.Backend
{

    public enum Team { RED, BLUE, YELLOW, GREEN };

    public interface ITeam
    {
        Team Team { get; set; }

    }
}
