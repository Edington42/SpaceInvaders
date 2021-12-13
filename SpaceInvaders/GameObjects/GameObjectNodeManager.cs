using SpaceInvaders.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    public class GameObjectNodeManager : Manager.Manager
    {
        //Singleton instantiation

        //Compare node
        private readonly GameObjectNode poNodeCompare;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public GameObjectNodeManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new GameObjectNode();
            this.poNodeCompare.pObject = new NullGameObject();
        }

        /// <summary>
        /// Attaches a game object to the manager
        /// </summary>
        /// <param name="pObject">Game object to attach</param>
        /// <returns>new node containing the game object</returns>
        public GameObjectNode Attach(GameObject pObject)
        {
            //Generate the node
            GameObjectNode pNode = (GameObjectNode)BaseAdd();

            //Attach the object to the node
            pNode.Set(pObject);
            pNode.pManager = this;

            return pNode;
        }

        public GameObjectNode Pull()
        {
            //Generate the node
            GameObjectNode pNode = (GameObjectNode)BaseAdd();
            pNode.pManager = this;

            return pNode;
        }



        /// <summary>
        /// Finds a game object node by name
        /// </summary>
        /// <param name="name">Name of the game object node to find</param>
        /// <returns>Game object node coresponding to the name. Null if no such game object was found</returns>
        public GameObjectNode Find(GameObject.Name name)
        {
            this.poNodeCompare.pObject.name = name;

            GameObjectNode pNode = (GameObjectNode)BaseFind(this.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            GameObjectNode gameObjectA = (GameObjectNode)nodeA;
            GameObjectNode gameObjectB = (GameObjectNode)nodeB;

            bool match = false;

            //Compare the names of the attached objects
            if (gameObjectA.pObject.name == gameObjectB.pObject.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new GameObjectNode();
        }

        protected override void Wash(DLink pNode)
        {
        }
    }
}
