using SpaceInvaders.Composite;
using SpaceInvaders.DelayedRemove;
using SpaceInvaders.GameObjects.Ship;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ShipRemoveObserver : Observer
    {

        public override void Notify()
        {
            Leaf toRemove = (Leaf)ShipManager.GetInstance().GetShip();
            DelayRemoveManager.GetInstance().Attach(toRemove);
        }

        public override void Print()
        {
            Debug.WriteLine("Ship remove observer");
        }
    }
}
