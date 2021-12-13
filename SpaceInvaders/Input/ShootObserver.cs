using SpaceInvaders.GameObjects.Ship;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Input
{
    class ShootObserver : Observer.Observer
    {

        //---------------------------------------------------------------------------------------------------------
        // Override methods
        //---------------------------------------------------------------------------------------------------------
        public override void Notify()
        {
            //Debug.WriteLine("Shoot Observer");
            Ship pShip = ShipManager.GetInstance().GetShip();
            pShip.ShootMissile();
        }

        public override void Print()
        {
            Debug.WriteLine("Shoot Observer");
        }
    }
}
