using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class BombMoveEvent : Command
    {
        protected GameObject pObj;
        protected float delta = 10.0f * Screen.SCALE;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObj">Bomb group to move</param>
        public BombMoveEvent(GameObject pObj)
        {
            this.pObj = pObj;
        }


        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            //TODO this probably can be made generic for projectiles so missiles can use this with a differnt delta

            //Move each child of this object
            GameObject child = (GameObject)pObj.GetFirstChild();
            while(child != null)
            {
                child.y -= delta;
                child = (GameObject)child.GetSibling();
            }
        }
    }
}
