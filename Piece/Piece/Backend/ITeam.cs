using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.Backend
{
    public enum PlayerTeam { RED, GREEN, YELLOW, BLUE };

    public interface ITeam
    {

        PlayerTeam Team{
            get;
            set;
        }

    }
}
