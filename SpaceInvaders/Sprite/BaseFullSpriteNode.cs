using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Base class for sprites with full information.
    /// </summary>
    public abstract class BaseFullSpriteNode : BaseSpriteNode
    {
        public float sx;
        public float sy;
        public float angle;

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        protected override void ToDefault()
        {
            base.ToDefault();
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0;
        }
    }
}
