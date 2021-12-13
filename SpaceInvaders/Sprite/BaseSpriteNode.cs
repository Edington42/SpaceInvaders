using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Most basic sprite.
    /// </summary>
    public abstract class BaseSpriteNode : DLink
    {
        public float x;
        public float y;
        public SpriteContainer.SpriteContainer pSpriteContainer;


        //---------------------------------------------------------------------------------------------------------
        // Abstract Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Updates the sprite
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Renders the sprite
        /// </summary>
        public abstract void Render();

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        protected override void ToDefault()
        {
            this.x = 0;
            this.y = 0;
            this.pSpriteContainer = null; ;
    }
    }
}

