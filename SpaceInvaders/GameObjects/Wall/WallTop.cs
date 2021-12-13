using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Wall
{
    public class WallTop : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public WallTop(GameObject.Name name, float posX, float posY, float width, float height)
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
            other.VisitWallTop(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)m.GetFirstChild();
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(MissileObject m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(m, this);
        }



    }
}
