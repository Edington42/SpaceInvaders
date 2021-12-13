using System.Diagnostics;

namespace SpaceInvaders.Font
{

    //TODO this probably could jsut hold a array instead of using keys this way
    class Glyph : DLink
    {
        public Name name;
        public int key;
        private Azul.Rect pSubRect;
        private TextureNode pTexture;

        public enum Name
        {
            NullObject,
            Uninitialized,
            CONSOLAS_36_PT
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        
        public Glyph() 
            : base()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect = new Azul.Rect();
            this.key = 0;
        }


        public void Set(Glyph.Name name, int key, TextureNode.Name textName, float x, float y, float width, float height)
        {
            this.name = name;

            this.pTexture = TextureManager.GetInstance().Find(textName);

            this.pSubRect.Set(x, y, width, height);

            this.key = key;
        }

        public Azul.Rect GetAzulSubRect()
        {
            return this.pSubRect;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.pTexture.texture;
        }


        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine(name);
        }

        protected override void ToDefault()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect.Set(0, 0, 1, 1);
            this.key = 0;
        }

    }
}
