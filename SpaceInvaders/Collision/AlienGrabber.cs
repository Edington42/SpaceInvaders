using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    class AlienGrabber : ColGrabber
    {
        public override GameObject GetSubject(ColPairSubject pColPair)
        {
            ColPairSubject colPairSubject = (ColPairSubject)pColPair;
            return colPairSubject.GetByRootName(GameObject.Name.ALIEN_GRID);
        }
    }
}
