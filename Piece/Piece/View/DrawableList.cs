using System;
using System.Collections.Generic;
using System.Text;

namespace Ludoop.View
{
    public class DrawableList : List<IDraw>
    {

        public DrawableList() {

        }

        /// <summary>
        /// Method for drawing all actors in ActorList.
        /// </summary>
        public void DrawAll() {
            foreach(IDraw drawableItem in this) {
                drawableItem.Actor.Draw();
            }
        }

    }
}
