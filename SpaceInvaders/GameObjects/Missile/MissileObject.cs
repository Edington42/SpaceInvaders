using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Layer;
using SpaceInvaders.Observer;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    public class MissileObject : Leaf
    {

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {          
            other.VisitMissile(this);
        }
    }
}
