using SpaceInvaders.GameObjects.Ship;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Input
{
    class MoveLeftObserver : Observer.Observer
    {

        //---------------------------------------------------------------------------------------------------------
        // Override methods
        //---------------------------------------------------------------------------------------------------------
        public override void Notify()
        {
            //Debug.WriteLine("Shoot Observer");
            Ship pShip = ShipManager.GetInstance().GetShip();
            pShip.MoveLeft();
        }

        public override void Print()
        {
            Debug.WriteLine("Move Left Observer");
        }
    }
}
