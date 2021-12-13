using SpaceInvaders.Images;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Contains a sprite orignating from a texture.
    /// </summary>
    public class GameSpriteNode : BaseFullSpriteNode
    {
        public Name name;
        public ImageNode pImage;
        private Azul.Sprite pAzulSprite;

        /// <summary>
        ///Default values.
        /// </summary>
        static private Azul.Rect psDefaultRect = new Azul.Rect();
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        protected Azul.Rect poScreenRect = new Azul.Rect();

        /// <summary>
        /// Enum of sprite node names
        /// </summary>
        public enum Name
        {

            STITCH,

            YELLOW_BIRD,
            GREEN_BIRD,
            YELLOW_BIRD_2,
            GREEN_BIRD_2,

            CONSOLAS_0_TOP_LEFT,
            CONSOLAS_0_TOP_RIGHT,
            CONSOLAS_0_BOTTOM_LEFT,
            CONSOLAS_0_BOTTOM_RIGHT,
            CONSOLAS_0_OTHER,
            CONSOLAS_1,
            CONSOLAS_2,
            CONSOLAS_3,

            SQUID,
            CRAB,
            OCTOPUS,
            MISSILE,
            SHIP,

        

            UNINITIALIZED,
            NULL_OBJECT,
            BRICK,
            BRICK_TOP_LEFT_0,
            BRICK_TOP_LEFT_1,
            BRICK_BOTTOM_LEFT_0,
            BRICK_BOTTOM_LEFT_1,
            BRICK_TOP_RIGHT_0,
            BRICK_TOP_RIGHT_1,
            BRICK_BOTTOM_RIGHT_0,
            BRICK_BOTTOM_RIGHT_1,
            BRICK_BOTTOM,
            BOMB,
            SQUIGLY,
            PLUNGER,
            ROLLING,
            ALIEN_BOOM,
            MISSILE_BOOM,
            BOMB_BOOM,
            SHIP_BOOM,
            UFO,
            UFO_BOOM
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        public GameSpriteNode()
        {
            this.pImage = ImageManager.GetInstance().Find(ImageNode.Name.DEFAULT);

            this.name = Name.UNINITIALIZED;

            this.pAzulSprite = new Azul.Sprite(pImage.pTexture.texture, pImage.poRect, psDefaultRect);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;

        }

        /// <summary>
        /// Sets the variables for the sprite
        /// </summary>
        /// <param name="name">Name of the sprite</param>
        /// <param name="pTexture">Image node for the sprite</param>
        /// <param name="x">X location of image sprite</param>
        /// <param name="y">Y location if image sprite</param>
        /// <param name="width">Width of image sprite</param>
        /// <param name="height">Height of image sprite</param>
        /// /// <param name="r">Color of sprite</param>
        /// <param name="g">Color of sprite</param>
        /// <param name="b">Color of sprite</param>
        /// <param name="a">Color of sprite</param>
        public void Set(Name name, ImageNode pImage, float x, float y, float width, float height, float r, float g, float b, float a)
        {
            this.poScreenRect.Set(x, y, width, height);
            this.name = name;
            this.pImage = pImage;

            GameSpriteNode.psTmpColor.Set(r, g, b, a);

            this.pAzulSprite.Swap(pImage.pTexture.texture, pImage.poRect, poScreenRect, GameSpriteNode.psTmpColor);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        public void Set(Name name, ImageNode pImage, Screen2D screenSize, float r, float g, float b, float a)
        {
            //The position will be initially 0
            this.poScreenRect.Set(0, 0, screenSize.scaledScreenX, screenSize.scaledScreenY);
            this.name = name;
            this.pImage = pImage;

            GameSpriteNode.psTmpColor.Set(r, g, b, a);

            this.pAzulSprite.Swap(pImage.pTexture.texture, pImage.poRect, poScreenRect, GameSpriteNode.psTmpColor);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        /// <summary>
        /// Swaps the color 
        /// </summary>
        /// <param name="r">Color of sprite</param>
        /// <param name="g">Color of sprite</param>
        /// <param name="b">Color of sprite</param>
        /// <param name="a">Color of sprite</param>
        public void SwapColor(float r, float g, float b, float a = 1.0f)
        {
            GameSpriteNode.psTmpColor.Set(r, g, b, a);
            this.pAzulSprite.SwapColor(GameSpriteNode.psTmpColor);
        }

        /// <summary>
        /// Changes the image used for this sprite
        /// </summary>
        /// <param name="pNewImage">New image to use</param>
        public void SwapImage(ImageNode pNewImage)
        {
            this.pImage = pNewImage;

            this.pAzulSprite.SwapTexture(this.pImage.pTexture.texture);
            this.pAzulSprite.SwapTextureRect(this.pImage.poRect);
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the rectangle containing the sprite on the screen
        /// </summary>
        /// <returns>Rect containing the sprite</returns>
        public Azul.Rect GetScreenRect()
        {
            return this.poScreenRect;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Update()
        {
            this.pAzulSprite.x = this.x;
            this.pAzulSprite.y = this.y;
            this.pAzulSprite.sx = this.sx;
            this.pAzulSprite.sy = this.sy;
            this.pAzulSprite.angle = this.angle;

            this.pAzulSprite.Update();
        }

        public override void Render()
        {
            this.pAzulSprite.Render();
        }

        public override void Print()
        {
            Debug.WriteLine(this.name);
        }

        protected override void ToDefault()
        {
            base.ToDefault();

            this.pImage = null;
            this.name = Name.UNINITIALIZED;
        }
    }
}
