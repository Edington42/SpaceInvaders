using SpaceInvaders.Composite;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Manager;
using SpaceInvaders.Observer;
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
    public class AlienMoveEvent : Command
    {
        protected Subject pMoveSubject;


        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pObj">Component collection that will be moved.</param>
        public AlienMoveEvent(Subject pMoveSubject)
        {
            this.pMoveSubject = pMoveSubject;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            //Move all the aliens
            AlienGrid pObj = (AlienGrid)GameTreeManager.GetInstance().Find(GameObject.Name.ALIEN_GRID).pObject;
            pObj.March();
            pMoveSubject.Notify();
        }
    }
}
