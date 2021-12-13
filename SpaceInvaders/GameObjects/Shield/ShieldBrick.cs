using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Shield
{
    public class ShieldBrick : Leaf
    {

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the object to be created</param>
        /// <param name="spriteName">name of sprite the object will use</param>
        /// <param name="x">X coordinate of the object</param>
        /// <param name="y">Y coordinate of the object</param>

        public void Set(GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y)
        {
            BaseSet(name, spriteName, x, y);
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
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)m.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitBombGroup(BombGroup b)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            GameObject pGameObject = (GameObject)b.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitMissile(MissileObject m)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            //Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(this, m);

        }

        public override void VisitBomb(Bomb.Bomb b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(this, b);
        }

        public override void VisitGrid(AlienGrid a)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)a.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitColumn(AlienColumn a)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)a.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitAlienObject(AlienObject a)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", a.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(this, a);
        }


    }
}
