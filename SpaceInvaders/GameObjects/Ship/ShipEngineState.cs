using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    public abstract class ShipEngineState
    {
        public abstract void MoveRight(Ship pShip);

        public abstract void MoveLeft(Ship pShip);
    }
}
