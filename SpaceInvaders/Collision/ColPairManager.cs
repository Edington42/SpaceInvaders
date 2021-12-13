using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    /// <summary>
    /// Manages pairs of collision objects
    /// </summary>
    class ColPairManager : Manager.Manager
    {
        //Singleton instantiation
        private static ColPairManager pActiveMan = null;

        //Compare node
        private readonly ColPair poNodeCompare = null;

        //Current active collision pair
        public ColPair pActiveColPair = null;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public ColPairManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new ColPair();
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static ColPairManager GetInstance()
        {
            return ColPairManager.pActiveMan;
        }

        public static void SetActive(ColPairManager colPairManager)
        {
            ColPairManager.pActiveMan = colPairManager;
        }

        /// <summary>
        /// Adds a col pair to the manager
        /// </summary>
        /// <param name="name">name of the pair</param>
        /// <param name="treeRootA">First tree to collide</param>
        /// <param name="treeRootB">Second tree to collide</param>
        /// <returns></returns>
        public ColPair Add(ColPair.Name name, GameObject treeRootA, GameObject treeRootB)
        {
            ColPair pNode = (ColPair)BaseAdd();

            //Initialize the data
            pNode.Set(name, treeRootA, treeRootB);

            return pNode;
        }

        /// <summary>
        /// Processes all ofthe collision pairs in the manager
        /// </summary>
        public void Process()
        {
            ColPair pColPair = (ColPair)this.BaseGetActive();

            while (pColPair != null)
            {
                //Set the current pair being processed
                this.pActiveColPair = pColPair;

                // do the check for a single pair
                pColPair.Process();

                // advance to next
                pColPair = (ColPair)pColPair.pNext;
            }
        }

        /// <summary>
        /// The manager will process the current active collision pair based on the given objects
        /// </summary>
        /// <param name="pObjA">First object of the collision</param>
        /// <param name="pObjB">Second object of the collision</param>
        public void ProcessCol(GameObject pObjA, GameObject pObjB)
        {
            //Get the current collision pair being processed
            ColPair pColPair = this.GetActiveColPair();

            //Set the subject values to the objects of the collision
            pColPair.subject.pObjA = pObjA;
            pColPair.subject.pObjB = pObjB;

            //Notify the observers
            pColPair.subject.Notify();
        }

        /// <summary>
        /// Reutrns the active collision pair being processed
        /// </summary>
        /// <returns>Collision pair currently being processed</returns>
        private ColPair GetActiveColPair()
        {
            return this.pActiveColPair;
        }

        /// <summary>
        /// Finds a node node by name
        /// </summary>
        /// <param name="name">Name of the node node to find</param>
        /// <returns>Node coresponding to the name. Null if no such node was found</returns>
        public ColPair Find(ColPair.Name name)
        {
            this.poNodeCompare.name = name;

            ColPair pNode = (ColPair)BaseFind(this.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override DLink GetBlank()
        {
            return new ColPair();
        }

        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            ColPair pNodeA = (ColPair)nodeA;
            ColPair pNodeB = (ColPair)nodeB;

            bool match = false;

            if (pNodeA.name == pNodeB.name) match = true;

            return match;
        }

        protected override void Wash(DLink pNode)
        {
            ColPair pToWash = (ColPair)pNode;
            pToWash.Wash();
        }
    }
}
