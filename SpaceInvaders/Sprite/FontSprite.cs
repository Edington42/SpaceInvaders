using SpaceInvaders.Font;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    class FontSprite : BaseFullSpriteNode
    {
        public Name name;
        private Azul.Color pColor;   // this color is multplied by the texture

        private String pMessage;
        public Glyph.Name glyphName;

        static private Azul.Sprite psTmpSprite = new Azul.Sprite();
        static private Azul.Rect psTmpRect = new Azul.Rect(1, 1, 1, 1);

        public enum Name
        {
            TestMessage,
            TestOneOff,
            LIFE_COUNT,

            NullObject,
            Uninitialized,
            GAME_OVER_LABEL,
            P2_SCORE_LABEL,
            HIGH_SCORE_LABEL,
            P1_SCORE,
            P2_SCORE,
            HIGH_SCORE
        };

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        public FontSprite() : base()
        {
            this.pColor = new Azul.Color(1.0f, 1.0f, 1.0f);

            this.pMessage = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

        }

        public void Set(Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            this.pMessage = pMessage;

            this.x = xStart;
            this.y = yStart;

            this.name = name;

            this.glyphName = glyphName;

            // Force color to white
            this.pColor.Set(1.0f, 1.0f, 1.0f);
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
            this.pColor.Set(r, g, b, a);
        }

        public void UpdateMessage(String pMessage)
        {
            this.pMessage = pMessage;
        }


        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Update()
        {
            //Do nothing
        }

        public override void Render()
        {

            float xTmp = this.x;
            float yTmp = this.y;

            float xEnd = this.x;

            for (int i = 0; i < this.pMessage.Length; i++)
            {
                int key = Convert.ToByte(pMessage[i]);

                Glyph pGlyph = GlyphManager.GetInstance().Find(this.glyphName, key);

                xTmp = xEnd + (pGlyph.GetAzulSubRect().width * Screen.SCALE) / 2;
                psTmpRect.Set(xTmp, yTmp, pGlyph.GetAzulSubRect().width*Screen.SCALE, pGlyph.GetAzulSubRect().height* Screen.SCALE);

                psTmpSprite.Swap(pGlyph.GetAzulTexture(), pGlyph.GetAzulSubRect(), psTmpRect, this.pColor);

                psTmpSprite.Update();
                psTmpSprite.Render();

                // move the starting to the next character
                xEnd = (pGlyph.GetAzulSubRect().width * Screen.SCALE) / 2 + xTmp;

            }
        }

        public override void Print()
        {
            Debug.WriteLine("Font: " + this.pMessage);
        }

        protected override void ToDefault()
        {
            base.ToDefault();

            this.pColor.Set(1.0f, 1.0f, 1.0f);

            this.pMessage = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
        }
    }
}
