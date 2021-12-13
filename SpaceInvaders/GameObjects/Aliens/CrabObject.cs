using SpaceInvaders.Collision;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    /// <summary>
    /// Crab alien object.
    /// </summary>
    public class CrabObject : AlienObject
    {

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override int GetScore()
        {
            return 20;
        }
    }
}
