using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects.Bomb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    public class ShipGroup : Composite.Composite
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the object to be created</param>
        public ShipGroup(Name name) : base(name)
        {
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitShipGroup(this);
        }

        public override void VisitBomb(Bomb.Bomb b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            GameObject pGameObject = (GameObject)this.GetFirstChild();
            ColPair.Collide(b, pGameObject);
        }

        public override void VisitBombGroup(BombGroup b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            GameObject pGameObject = (GameObject)b.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }
    }
}
