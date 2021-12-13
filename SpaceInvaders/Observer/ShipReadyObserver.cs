using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects.Ship;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ShipReadyObserver : Observer
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetInstance().GetShip();
            pShip.ReloadMissile();
        }

        public override void Print()
        {
            Debug.WriteLine("Ship ready Observer");
        }
    }
}
