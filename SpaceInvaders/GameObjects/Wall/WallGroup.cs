using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Wall
{
    public class WallGroup : Composite.Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the object to be created</param>
        public WallGroup(Name name) : base(name)
        {
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitWallGroup(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            // MissileRoot vs WallRoot
            GameObject pGameObj = (GameObject)m.GetFirstChild();
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(MissileObject m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitBombGroup(BombGroup b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(b, pGameObj);
        }

        public override void VisitBomb(Bomb.Bomb b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(b, pGameObj);
        }

        public override void  VisitGrid(AlienGrid b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(b, pGameObj);
        }

        public override void VisitShipGroup(ShipGroup s)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", s.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(s, pGameObj);
        }

        public override void VisitUfoGroup(UfoGroup u)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", u.name, this.name);
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)this.GetFirstChild();
            ColPair.Collide(u, pGameObj);
        }
    }
}
