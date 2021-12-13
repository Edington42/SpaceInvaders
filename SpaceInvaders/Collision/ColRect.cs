using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    /// <summary>
    /// Rectangle used for a collision boundry
    /// </summary>
    public class ColRect : Azul.Rect
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X value of rect</param>
        /// <param name="y">Y value of rect</param>
        /// <param name="width">Width of rect</param>
        /// <param name="height">Height of rect</param>
         public ColRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pRect">Rectangle to use as collision boundry</param>
        public ColRect(Azul.Rect pRect)
            : base(pRect)
        {
        }

        /// <summary>
        /// Construcor
        /// </summary>
        /// <param name="pRect">Collision rectangle to use as collison boundry</param>
        public ColRect(ColRect pRect)
            : base(pRect)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ColRect()
            : base()
        {
        }

        /// <summary>
        /// Checks if two rect intersect
        /// </summary>
        /// <param name="ColRectA">First rect being checked</param>
        /// <param name="ColRectB">Second rect being checked</param>
        /// <returns>True if they interesct</returns>
        static public bool Intersect(ColRect ColRectA, ColRect ColRectB)
        {
            bool status = false;

            float A_minx = ColRectA.x - ColRectA.width / 2;
            float A_maxx = ColRectA.x + ColRectA.width / 2;
            float A_miny = ColRectA.y - ColRectA.height / 2;
            float A_maxy = ColRectA.y + ColRectA.height / 2;

            float B_minx = ColRectB.x - ColRectB.width / 2;
            float B_maxx = ColRectB.x + ColRectB.width / 2;
            float B_miny = ColRectB.y - ColRectB.height / 2;
            float B_maxy = ColRectB.y + ColRectB.height / 2;

            // Trivial reject
            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }


            return status;
        }

        /// <summary>
        /// Adds a given rectangle to this by expanding th
        /// </summary>
        /// <param name="ColRect">Rect to include</param>
        public void Union(ColRect ColRect)
        {
            float minX;
            float minY;
            float maxX;
            float maxY;


            if ((this.x - this.width / 2) < (ColRect.x - ColRect.width / 2))
            {
                minX = (this.x - this.width / 2);
            }
            else
            {
                minX = (ColRect.x - ColRect.width / 2);
            }

            if ((this.x + this.width / 2) > (ColRect.x + ColRect.width / 2))
            {
                maxX = (this.x + this.width / 2);
            }
            else
            {
                maxX = (ColRect.x + ColRect.width / 2);
            }

            if ((this.y + this.height / 2) > (ColRect.y + ColRect.height / 2))
            {
                maxY = (this.y + this.height / 2);
            }
            else
            {
                maxY = (ColRect.y + ColRect.height / 2);
            }

            if ((this.y - this.height / 2) < (ColRect.y - ColRect.height / 2))
            {
                minY = (this.y - this.height / 2);
            }
            else
            {
                minY = (ColRect.y - ColRect.height / 2);
            }

            this.width = (maxX - minX);
            this.height = (maxY - minY);
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2;
        }
    }
}
