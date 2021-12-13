using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureNode : DLink
    {
        public Azul.Texture texture;
        public Name name;

        static private readonly Azul.Texture pDefaultTexture = new Azul.Texture("HotPink.tga");

        /// <summary>
        /// Enum of texture node names
        /// </summary>
        public enum Name
        {
            ALIENS,
            STITCH,
            BIRDS,
            CONSOLAS,
            HOT_PINK,
            SPACE_INVADERS,
            DEFAULT,
            UNINITILIZED,
            CONSOLAS_36_PT
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Populates the node with the given values
        /// </summary>
        /// <param name="name">Name of the node</param>
        /// <param name="pTextureFileName">Name of texture file</param>
        public void Set(Name name, string pTextureFileName)
        {
            this.name = name;
            this.texture = new Azul.Texture(pTextureFileName);
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
            this.texture = pDefaultTexture;
            this.name = Name.UNINITILIZED;
        }

    }
}
