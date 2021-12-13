using SpaceInvaders.Font;
using SpaceInvaders.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    class FontSpriteManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 3;
        private static int GROWTH_SIZE = 2;
        private static FontSpriteManager instatnce = new FontSpriteManager(RESERVE_SIZE, GROWTH_SIZE);

        //Compare node
        private readonly FontSprite poNodeCompare = null;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private FontSpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new FontSprite();
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static FontSpriteManager GetInstance()
        {
            return instatnce;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instatnce);
            FontSpriteManager.instatnce = null;
        }

        public FontSprite Add(FontSprite.Name name, Layer.Layer.Name layerName, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontSprite pNode = (FontSprite)BaseAdd();

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            LayerManager.GetInstance().AttachToLayer(layerName, pNode);

            return pNode;
        }

        /// <summary>
        /// Finds a texture node by name
        /// </summary>
        /// <param name="name">Name of the texture node to find</param>
        /// <returns>Texture node coresponding to the name. Null if no such texture was found</returns>
        public FontSprite Find(FontSprite.Name name)
        {
            instatnce.poNodeCompare.name = name;

            FontSprite pNode = (FontSprite)BaseFind(instatnce.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override DLink GetBlank()
        {
            return new FontSprite();
        }

        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            FontSprite pTextureNodeA = (FontSprite)nodeA;
            FontSprite pTextureNodeB = (FontSprite)nodeB;

            bool match = false;

            if (pTextureNodeA.name == pTextureNodeB.name) match = true;

            return match;
        }

        protected override void Wash(DLink pNode)
        {
            FontSprite pToWash = (FontSprite)pNode;
            pToWash.Wash();
        }
    }
}
