using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.SpriteContainer
{
    /// <summary>
    /// Contains a base sprite.
    /// </summary>
    public class SpriteContainer : DLink
    {
        public BaseSpriteNode poSprite;
        public SpriteContainerManager pSpriteContainerManager;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
       /// <summary>
       /// Sets the sprite to be contained
       /// </summary>
       /// <param name="name">Name of sprite to contain</param>
        public void Set(GameSpriteNode.Name name)
        {
            this.poSprite = GameSpriteManager.GetInstance().Find(name);
            this.AttachBackPointer();
        }

        /// <summary>
        /// Sets the box sprite to be contained
        /// </summary>
        /// <param name="name">Name of sprite to contain</param>
        public void Set(BoxSpriteNode.Name name)
        {
            this.poSprite = BoxSpriteManager.GetInstance().Find(name);
            this.AttachBackPointer();
        }

        /// <summary>
        /// :Lazy version to fix
        /// </summary>
        /// <param name="pSprite">Sprite to contain</param>
        public void Set(BaseSpriteNode pSprite)
        {
            this.poSprite = pSprite;
            this.AttachBackPointer();
        }

        private void AttachBackPointer()
        {
            this.poSprite.pSpriteContainer = this;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine("Container: ");
            poSprite.Print();
        }

        protected override void ToDefault()
        {
            this.poSprite = null;
            this.pSpriteContainerManager = null;
        }
    }
}
