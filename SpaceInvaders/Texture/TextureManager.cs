using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class TextureManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 3;
        private static int GROWTH_SIZE = 2;
        private static TextureManager instatnce = new TextureManager(RESERVE_SIZE, GROWTH_SIZE);

        //Compare node
        private readonly TextureNode poNodeCompare = null;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private TextureManager(int reserveSize, int growthSize) : base(reserveSize, growthSize){
            this.poNodeCompare = new TextureNode();

            //This manager will always start with a default texture
            TextureNode pNode = (TextureNode)BaseAdd();
            pNode.name = TextureNode.Name.DEFAULT;
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static TextureManager GetInstance()
        {
            return instatnce;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instatnce);
            TextureManager.instatnce = null;
        }

        /// <summary>
        /// Adds a specified node to the active list and returns it
        /// </summary>
        /// <param name="name">Name of the node</param>
        /// <param name="pTextureFileName">Name of the texture file</param>
        /// <returns>Created node</returns>
        public TextureNode Add(TextureNode.Name name, string pTextureFileName)
        {
            TextureNode pNode = (TextureNode)BaseAdd();

            //Initialize the data
            pNode.Set(name, pTextureFileName);

            return pNode;
        }

        /// <summary>
        /// Finds a texture node by name
        /// </summary>
        /// <param name="name">Name of the texture node to find</param>
        /// <returns>Texture node coresponding to the name. Null if no such texture was found</returns>
        public TextureNode Find(TextureNode.Name name)
        {
            instatnce.poNodeCompare.name = name;

            TextureNode pNode = (TextureNode)BaseFind(instatnce.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override DLink GetBlank()
        {
            return new TextureNode();
        }

        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            TextureNode pTextureNodeA = (TextureNode)nodeA;
            TextureNode pTextureNodeB = (TextureNode)nodeB;

            bool match = false;

            if (pTextureNodeA.name == pTextureNodeB.name) match = true;

            return match;
        }

        protected override void Wash(DLink pNode)
        {
            TextureNode pToWash = (TextureNode)pNode;
            pToWash.Wash();
        }
    }
}
