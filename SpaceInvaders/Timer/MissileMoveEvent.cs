using SpaceInvaders.GameObjects;
using SpaceInvaders.Observer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    /// <summary>
    /// Command event that moves a collection of aliens.
    /// </summary>
    class MissileMoveEvent : Command
    {
        protected GameObject pObj;
        protected float delta = 10.0f * Screen.SCALE;
        protected Subject pSubject;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pObj">Missile to move</param>
        public MissileMoveEvent(GameObject pObj, Subject pSubject)
        {
            this.pObj = pObj;
            this.pSubject = pSubject;
            delta = 30.0f * Screen.SCALE;
        }


        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            //Boolean to track if any missiles moved
            bool moved = false;
            //Move each child of this object
            GameObject child = (GameObject)pObj.GetFirstChild();
            while (child != null)
            {
                moved = true;
                child.y += delta;
                child = (GameObject)child.GetSibling();
            }
            if(moved)pSubject.Notify();
        }
    }
}
