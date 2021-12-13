using SpaceInvaders.Util;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Images
{
    public class ImageNode : DLink
    {
        public Name name;
        public Azul.Rect poRect = new Azul.Rect();
        public TextureNode pTexture;

        /// <summary>
        /// Enum of image node names
        /// </summary>
        public enum Name
        {
            ALIEN,

            STITCH,

            RED_BIRD,
            YELLOW_BIRD,
            GREEN_BIRD,
            WHITE_BIRD,

            CONSOLAS_0,
            CONSOLAS_1,
            CONSOLAS_2,
            CONSOLAS_3,
            CONSOLAS_4,
            CONSOLAS_5,
            CONSOLAS_6,
            CONSOLAS_7,
            CONSOLAS_8,
            CONSOLAS_9,

            SQUID_OPEN,
            SQUID_CLOSED,

            CRAB_OPEN,
            CRAB_CLOSED,

            OCTO_OPEN,
            OCTO_CLOSED,

            MISSILE,

            SHIP,

            DEFAULT,

            UNINITIALIZED,
            BRICK_TOP_LEFT,
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
            SQUIGLY_0,
            SQUIGLY_1,
            SQUIGLY_2,
            SQUIGLY_3,
            PLUNGER_0,
            PLUNGER_1,
            PLUNGER_2,
            PLUNGER_3,
            ROLLING_0,
            ROLLING_1,
            ROLLING_2,
            ROLLING_3,
            ALIEN_BOOM,
            BOMB_BOOM,
            MISSILE_BOOM,
            SHIP_BOOM_0,
            SHIP_BOOM_1,
            UFO,
            UFO_BOOM
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public ImageNode(): base() { 
        }

        /// <summary>
        /// Sets the variables for the image
        /// </summary>
        /// <param name="name">Name of the image</param>
        /// <param name="pTexture">Texture node for the image</param>
        /// <param name="x">X location of image rect</param>
        /// <param name="y">Y location of image rect</param>
        /// <param name="width">Width of image rect</param>
        /// <param name="height">Height of image rect</param>
        public void Set(Name name, TextureNode pTexture, float x, float y, float width, float height)
        {
            this.name = name;

            this.pTexture = pTexture;

            this.poRect.Set(x, y, width, height);
        }

        public void Set(Name name, TextureNode pTexture, TextureSize textureSize)
        {
            this.name = name;

            this.pTexture = pTexture;

            this.poRect.Set(textureSize.textureX, textureSize.textureY, textureSize.textureWidth, textureSize.textureHeight);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Print()
        {
            Debug.WriteLine(this.name);
        }

        protected override void ToDefault()
        {
            this.pTexture = null;
            this.name = Name.UNINITIALIZED;
            this.poRect.Clear();
        }
    }
}
