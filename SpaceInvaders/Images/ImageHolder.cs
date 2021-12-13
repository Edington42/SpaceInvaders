using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Images
{
    /// <summary>
    /// Holds an ImageNode in a single linked list node
    /// </summary>
    class ImageHolder : SLink
    {
        public ImageNode pImage;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image node to hold</param>
        public ImageHolder(ImageNode image) : base()
        {
            this.pImage = image;
        }
    }
}
