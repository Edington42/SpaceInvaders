using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.SpriteContainer
{
    /// <summary>
    /// Maanges sprite containers.
    /// </summary>
    public class SpriteContainerManager : Manager.Manager
    {

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        //Compare node
        private readonly SpriteContainer poNodeCompare;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public SpriteContainerManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new SpriteContainer();
        }

        /// <summary>
        /// Attaches a sprite node to this manager by name and returns the resulting conatainer 
        /// </summary>
        /// <param name="name">Name of sprite node to attach</param>
        /// <returns>Sprite container that holds the specified sprite node</returns>
        public SpriteContainer Attach(GameSpriteNode.Name name)
        {
            SpriteContainer pNode = (SpriteContainer)this.BaseAdd();

            pNode.Set(name);
            this.AttachBackPointer(pNode);

            return pNode;
        }

        /// <summary>
        /// Attaches a sprite to the layer
        /// </summary>
        /// <param name="pSprite">Spritee to attach/param>
        /// <returns>Sprite container that holds the specified sprite node</returns>
        public SpriteContainer Attach(BaseSpriteNode pSprite)
        {
            SpriteContainer pNode = (SpriteContainer)this.BaseAdd();

            pNode.Set(pSprite);
            this.AttachBackPointer(pNode);

            return pNode;
        }

        /// <summary>
        /// Attaches a box sprite node to this manager by name and returns the resulting conatainer 
        /// </summary>
        /// <param name="name">Name of sprite node to attach</param>
        /// <returns>Sprite container that holds the specified sprite node</returns>
        public SpriteContainer Attach(BoxSpriteNode.Name name)
        {
            SpriteContainer pNode = (SpriteContainer)this.BaseAdd();

            pNode.Set(name);
            this.AttachBackPointer(pNode);

            return pNode;
        }

        /// Renders the nodes managed by this manager
        /// <summary>
        /// </summary>
        public void Draw()
        {
            SpriteContainer pNode = (SpriteContainer)this.BaseGetActive();

            while (pNode != null)
            {
                pNode.poSprite.Render();

                pNode = (SpriteContainer)pNode.pNext;
            }
        }

        /// <summary>
        /// Removes a container of the given sprite
        /// </summary>
        /// <param name="pSpriteNode">Sprite whoes container should be removed</param>
        public void Remove(BaseSpriteNode pSpriteNode)
        {
            SpriteContainer pContainer = this.Find(pSpriteNode);
            this.Remove(pContainer);
        }

        /// <summary>
        /// Finds a sprte container from the sprite it contains
        /// </summary>
        /// <param name="pSpriteNode">Sprite to look for</param>
        /// <returns>Sprite container that has the give sprite</returns>
        public SpriteContainer Find(BaseSpriteNode pSpriteNode)
        {
            this.poNodeCompare.Set(pSpriteNode);
            return (SpriteContainer)BaseFind(this.poNodeCompare);
        }

        public void AttachBackPointer(SpriteContainer pSpriteContainer)
        {
            pSpriteContainer.pSpriteContainerManager = this;
        }

        public void Accept(SpriteContainerManager pManager)
        {
            this.pActive = pManager.pActive;
            this.pActiveTail = pManager.pActiveTail;
            this.mNumActive = pManager.mNumActive;

            SpriteContainer pNode = (SpriteContainer)this.BaseGetActive();
            while(pNode != null)
            {
                this.AttachBackPointer(pNode);
                pNode = (SpriteContainer)pNode.pNext;
            }

            pManager.pActive = null;
            pManager.pActiveTail = null;
            pManager.mNumActive = 0;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            SpriteContainer containerA = (SpriteContainer)nodeA;
            SpriteContainer containerB = (SpriteContainer)nodeB;

            return containerA.poSprite.GetHashCode() == containerB.poSprite.GetHashCode();
        }

        protected override DLink GetBlank()
        {
            DLink pNode = new SpriteContainer();

            return pNode;
        }

        protected override void Wash(DLink pNode)
        {
            SpriteContainer pContainer = (SpriteContainer)pNode;
            pContainer.Wash();
        }
    }
}
