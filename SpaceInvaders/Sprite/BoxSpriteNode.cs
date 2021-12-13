using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Container for a box sprite.
    /// </summary>
    public class BoxSpriteNode : BaseFullSpriteNode
    {
        public Name name;
        private Azul.SpriteBox pAzulSprite;
        public Azul.Color poLineColor;

        
        static private Azul.Rect psDefaultRect = new Azul.Rect(1,1,1,1);
        static private Azul.Rect psTmpRect = new Azul.Rect(1, 1, 1, 1);
        static private Azul.Color psDefaultColor = new Azul.Color(1, 1, 1);

        /// <summary>
        /// Enum of sprite node names
        /// </summary>
        public enum Name
        {

            BIG_BOX,
            LITTLE_BOX,
            RED_BOX,
            BLUE_BOX,
            BOX,

            

            UNINITIALIZED
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        public BoxSpriteNode() : base()
        {

            this.name = Name.UNINITIALIZED;

            this.pAzulSprite = new Azul.SpriteBox(psDefaultRect, psDefaultColor);

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
            this.poLineColor = new Azul.Color(1, 1, 1);

        }

        /// <summary>
        /// Sets the variables for the sprite
        /// </summary>
        /// <param name="name">Name of the sprite</param>
        /// <param name="x">X location of sprite</param>
        /// <param name="y">Y location if sprite</param>
        /// <param name="width">Width of sprite</param>
        /// <param name="height">Height of sprite</param>
        /// <param name="r">Color of sprite</param>
        /// <param name="g">Color of sprite</param>
        /// <param name="b">Color of sprite</param>
        /// <param name="a">Color of sprite</param>
        public void Set(Name name,  float x, float y, float width, float height, float r, float g, float b, float a)
        {
            BoxSpriteNode.psTmpRect.Set(x, y, width, height);
            this.name = name;


            this.poLineColor.Set(r, g, b, a);

            this.pAzulSprite.Swap(BoxSpriteNode.psTmpRect, this.poLineColor);
            

            this.x = pAzulSprite.x;
            this.y = pAzulSprite.y;
            this.sx = pAzulSprite.sx;
            this.sy = pAzulSprite.sy;
            this.angle = pAzulSprite.angle;
        }

        /// <summary>
        /// Sets the rectangle without changing the line color
        /// </summary>
        /// <param name="name">NAme fo the sprite</param>
        /// <param name="x">X psotion of the sprite</param>
        /// <param name="y">Y position of the spirte</param>
        /// <param name="width">Width of the sprite</param>
        /// <param name="height">height of the sprite</param>
        public void Set(Name name, float x, float y, float width, float height)
        {
            BoxSpriteNode.psTmpRect.Set(x, y, width, height);
            this.name = name;

            this.pAzulSprite.Swap(BoxSpriteNode.psTmpRect, this.poLineColor);


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
            this.poLineColor.Set(r, g, b, a);
            this.pAzulSprite.SwapColor(poLineColor);
        }

        /// <summary>
        /// Updates the rect to the give parameters
        /// </summary>
        /// <param name="x">X position to set to </param>
        /// <param name="y">Y positon to set to</param>
        /// <param name="width">Width t set</param>
        /// <param name="height">Height to set</param>
        public void UpdateRect(float x, float y, float width, float height)
        {
            this.Set(this.name, x, y, width, height);
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

            this.name = Name.UNINITIALIZED;
            this.poLineColor.Set(1, 1, 1);
        }
    }
}
