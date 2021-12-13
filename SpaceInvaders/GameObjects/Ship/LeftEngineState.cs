using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    class LeftEngineState : ShipEngineState
    {
        public override void MoveLeft(Ship pShip)
        {
          //Do nothing
        }

        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
            pShip.SetEngineState(ShipManager.EngineState.DEFAULT);
        }
    }
}
