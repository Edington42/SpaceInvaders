using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Util
{
    public class Screen2D
    {
        public readonly float screenX;
        public readonly float screenY;

        public readonly float scaledScreenX;
        public readonly float scaledScreenY;

        public Screen2D(float screenX, float screenY)
        {

            this.screenX = screenX;
            this.screenY = screenY;
            this.scaledScreenX = this.screenX * Screen.SCALE;
            this.scaledScreenY = this.screenY * Screen.SCALE;
        }
    }
}
