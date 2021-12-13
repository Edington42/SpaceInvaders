using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.UFO
{
    public class Ufo : Leaf
    {
        private int score;


        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public Ufo()
        {
            score = 0;
        }

        public void Set(GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y, int score)
        {
            this.score = score;
            BaseSet(name, spriteName, x, y);
        }

        public int GetScore()
        {
            return this.score;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitUfo(this);
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

