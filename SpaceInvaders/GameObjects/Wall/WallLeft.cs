using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Wall
{
    //TODO oher than location, I think these walls are identical and could be converted to side walls
    public class WallLeft : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public WallLeft(GameObject.Name name, float posX, float posY, float width, float height)
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
            other.VisitWallLeft(this);
        }

        public override void VisitGrid(AlienGrid b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(b, this);
        }

        public override void VisitShipGroup(ShipGroup s)
        {
            // ShipGroup vs Wall
            GameObject pGameObj = (GameObject)s.GetFirstChild();
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitShip(Ship.Ship s)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", s.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(s, this);
        }

        public override void VisitUfoGroup(UfoGroup r)
        {
            // ShipGroup vs Wall
            GameObject pGameObj = (GameObject)r.GetFirstChild();
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitUfo(Ufo u)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", u.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(u, this);
        }

    }
}
