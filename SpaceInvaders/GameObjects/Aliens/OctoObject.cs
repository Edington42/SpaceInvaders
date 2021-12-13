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
    /// Octopus alien object.
    /// </summary>
    public class OctoObject : AlienObject
    {

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override int GetScore()
        {
            return 10;
        }
    }
}
