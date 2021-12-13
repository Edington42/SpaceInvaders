using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Shield
{
    public class ShieldGrid : Composite.Composite
    {
        //Prototype for alien grid 
        public Subject pSubject;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the object to be created</param>
        public ShieldGrid(Name name) : base(name)
        {
            this.pSubject = new Subject();
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            throw new NotImplementedException();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)this.GetFirstChild();
            ColPair.Collide(m, pGameObject);
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

        public override void VisitColumn(AlienColumn a)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", a.name, this.name);
            GameObject pGameObject = (GameObject)this.GetFirstChild();
            ColPair.Collide(a, pGameObject);
        }
    }
}
