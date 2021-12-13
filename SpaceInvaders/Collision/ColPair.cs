using SpaceInvaders.GameObjects;
using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    /// <summary>
    /// Holds a pair of collision objects
    /// </summary>
    public class ColPair : DLink
    {
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;
        public ColPairSubject subject;

        public enum Name 
        {
            ALIEN_MISSILE,
            UNINITIALIZED,
            WALL_MISSILE,
            ALIEN_WALL,
            ALIEN_RIGHT,
            ALIEN_LEFT,
            SHIELD_MISSILE,
            SHIELD_BOMB,
            WALL_BOMB,
            SHIP_LEFT,
            SHIP_RIGHT,
            SHIP_BOMB,
            MISSILE_BOMB,
            WALL_UFO,
            WALL_LEFT_UFO,
            MISSILE_UFO,
            WALL_RIGHT_UFO,
            ALIEN_SHIELD,
            ALIEN_BOTTOM
        }

        public ColPair()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.UNINITIALIZED;
            this.subject = new ColPairSubject();
        }


        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

       /// <summary>
       /// Sets the col pair up with the col trees
       /// </summary>
       /// <param name="name">Name of the pair</param>
       /// <param name="pTreeRootA">Game object tree A</param>
       /// <param name="pTreeRootB">Game object tree B</param>
        public void Set(Name name, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = name;
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

             while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    

                    // Get rectangles
                    ColRect rectA = pNodeA.poColObj.pColRect;
                    ColRect rectB = pNodeB.poColObj.pColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)pNodeB.GetSibling();
                }

                pNodeA = (GameObject)pNodeA.GetSibling();
            }
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine(name);
        }

        protected override void ToDefault()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.UNINITIALIZED;
            this.subject.Clear();
        }

    }
}

