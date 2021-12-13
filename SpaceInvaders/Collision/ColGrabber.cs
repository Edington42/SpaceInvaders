using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    public abstract class ColGrabber
    {
        public abstract GameObject GetSubject(ColPairSubject pColPair);
    }
}
