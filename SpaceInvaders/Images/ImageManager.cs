using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Images
{
    class ImageManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 5;
        private static int GROWTH_SIZE = 3;
        private static ImageManager instatnce = new ImageManager(RESERVE_SIZE, GROWTH_SIZE);

        //Compare node
        private readonly ImageNode poNodeCompare;

        //Texture manager to use
        TextureManager textureManager;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private ImageManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new ImageNode();
            this.textureManager = TextureManager.GetInstance();

            //Add a default image
            this.Add(ImageNode.Name.DEFAULT, TextureNode.Name.DEFAULT, 0, 0, 128, 128);
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static ImageManager GetInstance()
        {
            return instatnce;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instatnce);
            ImageManager.instatnce = null;
        }

        /// <summary>
        /// Creates a new image node
        /// </summary>
        /// <param name="name">name of image node</param>
        /// <param name="textureName">Name of texture to use for image</param>
        /// <param name="x">X location of image rect</param>
        /// <param name="y">Y location if image rect</param>
        /// <param name="width">Width of image rect</param>
        /// <param name="height">Height of image rect</param>
        /// <returns>New image node</returns>
        public ImageNode Add(ImageNode.Name name, TextureNode.Name textureName, float x, float y, float width, float height)
        {
            ImageNode pNode = (ImageNode)BaseAdd();

            //Initialize the data
            pNode.Set(name, textureManager.Find(textureName), x, y, width, height);

            return pNode;
        }

        public ImageNode Add(ImageNode.Name name, TextureNode.Name textureName, TextureSize textureSize)
        {
            ImageNode pNode = (ImageNode)BaseAdd();

            //Initialize the data
            pNode.Set(name, textureManager.Find(textureName), textureSize);

            return pNode;
        }

        /// <summary>
        /// Finds an image node by name
        /// </summary>
        /// <param name="name">Name of the image node to find</param>
        /// <returns>Image node coresponding to the name. Null if no such image was found</returns>
        public ImageNode Find(ImageNode.Name name)
        {
            instatnce.poNodeCompare.name = name;

            ImageNode pNode = (ImageNode)BaseFind(instatnce.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            ImageNode imageNodeA = (ImageNode)nodeA;
            ImageNode imageNodeB = (ImageNode)nodeB;

            bool match = false;

            if (imageNodeA.name == imageNodeB.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new ImageNode();
        }

        protected override void Wash(DLink pNode)
        {
            ImageNode pImageNode = (ImageNode)pNode;
            pImageNode.Wash();
        }
    }
}
