using SpaceInvaders.GameObjects.Ship;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ShipWallRightObserver : Observer
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetInstance().GetShip();
            pShip.SetEngineState(ShipManager.EngineState.RIGHT);
        }

        public override void Print()
        {
            Debug.WriteLine("Ship wall right Observer");
        }
    }
}
