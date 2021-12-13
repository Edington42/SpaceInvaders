using SpaceInvaders.Images;
using SpaceInvaders.Manager;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Sprite that acts as an animation command.
    /// </summary>
    class AnimationSprite : Command
    {
        private GameSpriteNode pSprite;
        private SCircleManager pCircleManager;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spriteName">Name of the sprite that will be animated.</param>
        public AnimationSprite(GameSpriteNode.Name spriteName)
        {
            // initialized the sprite animation is attached to
            this.pSprite = GameSpriteManager.GetInstance().Find(spriteName);
            Debug.Assert(this.pSprite != null);

            // initialize references
            pCircleManager = new SCircleManager();
        }
        
        /// <summary>
        /// Attaches an image node to be included in the animation.
        /// </summary>
        /// <param name="imageName">Image node to be included in the animation.</param>
        public void Attach(ImageNode.Name imageName)
        {
            // Get the image
            ImageNode pImage = ImageManager.GetInstance().Find(imageName);
            Debug.Assert(pImage != null);

            // Create a new holder
            ImageHolder pImageHolder = new ImageHolder(pImage);
            Debug.Assert(pImageHolder != null);

            this.pCircleManager.Add(pImageHolder);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            //Get the next image in the list
            ImageHolder pImageHolder = (ImageHolder)this.pCircleManager.GetNext();

                //Change the image
                this.pSprite.SwapImage(pImageHolder.pImage);
        }
    }
}
