using SpaceInvaders.Lives;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ResetShipObserver : Observer
    {
        public override void Notify()
        {
            TimerManager.GetInstance().Add(TimerEvent.Name.RESET, new ResetShipEvent(), 3.0f);

            
        }

        public override void Print()
        {
            Debug.WriteLine("Death transition observer");
        }
    }
}
