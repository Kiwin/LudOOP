using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public class ActorList : List<Actor>
    {

        public ActorList() {

        }

        /// <summary>
        /// Method for drawing all actors in ActorList.
        /// </summary>
        public void DrawAll() {
            foreach(Actor actor in this) {
                actor.Draw();
            }
        }

    }
}
