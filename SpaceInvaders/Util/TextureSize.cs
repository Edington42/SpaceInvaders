using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Util
{
    public class TextureSize
    {
        public readonly float textureX;
        public readonly float textureY;
        public readonly float textureWidth;
        public readonly float textureHeight;
        
        public TextureSize(float textureX, float textureY, float textureWidth, float textureHeight)
        {
            this.textureX = textureX;
            this.textureY = textureY;
            this.textureHeight = textureHeight;
            this.textureWidth = textureWidth;
        }
    }
}
