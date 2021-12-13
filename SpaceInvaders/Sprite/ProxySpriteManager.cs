using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Manages proxy sprites. Singleton.
    /// </summary>
    class ProxySpriteManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 5;
        private static int GROWTH_SIZE = 3;
        private static ProxySpriteManager instatnce = new ProxySpriteManager(RESERVE_SIZE, GROWTH_SIZE);

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private  ProxySpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static ProxySpriteManager GetInstance()
        {
            return ProxySpriteManager.instatnce;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instatnce);
            ProxySpriteManager.instatnce = null;
        }

        /// <summary>
        /// Creates a new proxy sprite
        /// </summary>
        /// <param name="spiteName">Sprite node that will be proxied</param>
        /// <param name="x">X location of sprite rect</param>
        /// <param name="y">Y location of sprite rect</param>
        /// <returns>New sprite node</returns>
        public ProxySprite Add(GameSpriteNode.Name spiteName, float x, float y)
        {
            ProxySprite pNode = (ProxySprite)BaseAdd();

            //Initialize the data
            pNode.Set(spiteName, x, y);

            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            ProxySprite spriteNodeA = (ProxySprite)nodeA;
            ProxySprite spriteNodeB = (ProxySprite)nodeB;

            bool match = false;

            //TODO find a better solution
            if (spriteNodeA.x == spriteNodeB.x && spriteNodeA.y == spriteNodeB.y) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new ProxySprite();
        }

        protected override void Wash(DLink pNode)
        {
            ProxySprite pSpriteNode = (ProxySprite)pNode;
            pSpriteNode.Wash();
        }
    }
}
