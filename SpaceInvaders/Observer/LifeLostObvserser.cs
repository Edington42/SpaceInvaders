using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Input;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class LifeLostObvserser : Observer
    {
        public override void Notify()
        {
            //Decrement lives
            TimerManager.GetInstance().Add(TimerEvent.Name.LIFE_LOST, new LifeLostEvent(), 2.0f);
        }

        public override void Print()
        {
            Debug.WriteLine("Life lost observer");
        }
    }
}
