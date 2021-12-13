using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    class RightEngineState : ShipEngineState
    {
        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
            pShip.SetEngineState(ShipManager.EngineState.DEFAULT);
        }

        public override void MoveRight(Ship pShip)
        {
            //Do nothing
        }
    }
}
