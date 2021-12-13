using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ResetUfoLaunchObserver : Observer
    {
        public override void Notify()
        {
            UfoManager.GetInstance().PrepUfo();
        }

        public override void Print()
        {
            Debug.WriteLine("Ufo wall observer");
        }
    }
}
