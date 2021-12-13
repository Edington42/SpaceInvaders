using SpaceInvaders.Composites;
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
    /// Node that will contain a game object.
    /// </summary>
    public class GameObjectNode : DLink
    {
        public GameObject pObject;
        public Manager.Manager pManager;

        /// <summary>
        /// Enum of image node names
        /// </summary>
        public enum Name
        {
            SQUID,

            CRAB,

            OCTO,

            DEFAULT,

            UNINITIALIZED
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        public GameObjectNode() : base()
        {
            this.pObject = null;
            this.pManager = null;
        }

        /// <summary>
        /// Sets the game object to be contained
        /// </summary>
        /// <param name="pObject">Object to be contained</param>
        public void Set(GameObject pObject)
        {
            this.pObject = pObject;
            this.pObject.backPointer = this;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Print()
        {
            Iterator iterator = new ForwardIterator(this.pObject);
            while (!iterator.IsDone())
            {
                iterator.Next().Print();
            }
        }

        protected override void ToDefault()
        {
            //this.pObject = null;
        }
    }
}
