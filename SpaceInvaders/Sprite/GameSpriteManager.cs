using SpaceInvaders.Images;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Manages game sprites.
    /// </summary>
    class GameSpriteManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 5;
        private static int GROWTH_SIZE = 3;
        private static GameSpriteManager instatnce = new GameSpriteManager(RESERVE_SIZE, GROWTH_SIZE);

        //Compare node
        private readonly GameSpriteNode poNodeCompare;

        //Image manager to use
        ImageManager imageManager;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private GameSpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new GameSpriteNode();
            this.imageManager = ImageManager.GetInstance();

            this.Add(GameSpriteNode.Name.NULL_OBJECT, ImageNode.Name.DEFAULT, 0, 0, 0, 0);
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static GameSpriteManager GetInstance()
        {
            return instatnce;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instatnce);
            GameSpriteManager.instatnce = null;
        }

        /// <summary>
        /// Creates a new sprite node
        /// </summary>
        /// <param name="name">name of sprite node</param>
        /// <param name="imageName">Name of image to use for sprite</param>
        /// <param name="x">X location of sprite rect</param>
        /// <param name="y">Y location if sprite rect</param>
        /// <param name="width">Width of sprite rect</param>
        /// <param name="height">Height of sprite rect</param>
        /// /// <param name="r">Color of sprite</param>
        /// <param name="g">Color of sprite</param>
        /// <param name="b">Color of sprite</param>
        /// <param name="a">Color of sprite</param>
        /// <returns>New sprite node</returns>
        public GameSpriteNode Add(GameSpriteNode.Name name, ImageNode.Name imageName, float x, float y, float width, float height, float r = 1.0f, float g = 1.0f, float b = 1.0f, float a = 1.0f)
        {
            GameSpriteNode pNode = (GameSpriteNode)BaseAdd();

            //Initialize the data
            pNode.Set(name, imageManager.Find(imageName), x, y, width, height, r, g, b, a);

            return pNode;
        }

        public GameSpriteNode Add(GameSpriteNode.Name name, ImageNode.Name imageName, Screen2D screenSize, float r = 1.0f, float g = 1.0f, float b = 1.0f, float a = 1.0f)
        {
            GameSpriteNode pNode = (GameSpriteNode)BaseAdd();

            //Initialize the data
            pNode.Set(name, imageManager.Find(imageName), screenSize, r, g, b, a);

            return pNode;
        }

        /// <summary>
        /// Finds an sprite node by name
        /// </summary>
        /// <param name="name">Name of the sprite node to find</param>
        /// <returns>prite node coresponding to the name. Null if no such sprite was found</returns>
        public GameSpriteNode Find(GameSpriteNode.Name name)
        {
            instatnce.poNodeCompare.name = name;

            GameSpriteNode pNode = (GameSpriteNode)BaseFind(instatnce.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            GameSpriteNode spriteNodeA = (GameSpriteNode)nodeA;
            GameSpriteNode spriteNodeB = (GameSpriteNode)nodeB;

            bool match = false;

            if (spriteNodeA.name == spriteNodeB.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new GameSpriteNode();
        }

        protected override void Wash(DLink pNode)
        {
            GameSpriteNode pSpriteNode = (GameSpriteNode)pNode;
            pSpriteNode.Wash();
        }
    }
}
