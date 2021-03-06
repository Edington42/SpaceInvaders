using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.GameObjects.Wall;
using SpaceInvaders.Layer;
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
    /// Alien game object that can move left and right.  Shares movement with others
    /// </summary>
    public abstract class AlienObject : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public void Set(GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y)
        {
            BaseSet(name, spriteName, x, y);
        }

        public abstract int GetScore();

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitAlienObject(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)m.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitMissile(MissileObject m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(this, m);
        }
    }
}
