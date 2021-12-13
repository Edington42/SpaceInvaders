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

namespace SpaceInvaders.GameObjects.Wall
{
    public class WallBottom : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public WallBottom(GameObject.Name name, float posX, float posY, float width, float height)
            : base()
        {
            this.name = name;
            this.poColObj.pColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SwapColor(0, 0, 0);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitWallBottom(this);
        }

        public override void VisitBombGroup(BombGroup b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);
            GameObject pGameObject = (GameObject)b.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }
         
        public override void VisitBomb(Bomb.Bomb b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(b, this);
        }

        public override void VisitGrid(AlienGrid a)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", a.name, this.name);
            GameObject pGameObject = (GameObject)a.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitColumn(AlienColumn a)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", a.name, this.name);
            GameObject pGameObject = (GameObject)a.GetFirstChild();
            ColPair.Collide(pGameObject, this);
        }

        public override void VisitAlienObject(AlienObject a)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", a.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(a, this);
        }



    }
}
