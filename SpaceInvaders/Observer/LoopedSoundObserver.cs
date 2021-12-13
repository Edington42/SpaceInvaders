using SpaceInvaders.Sounds;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class LoopedSoundObserver : Observer
    {
        Sound.Name name;
        float duration;

        public LoopedSoundObserver(Sound.Name name, float duration)
        {
            this.name = name;
            this.duration = duration;
        }

        public override void Notify()
        {
            SoundManager.GetInstance().Find(name).PlayLoop();
            TimerManager.GetInstance().Add(TimerEvent.Name.STOP_SHIP_BOOM, new StopSoundEvent(name), duration);
        }

        public override void Print()
        {
            Debug.WriteLine("Sound Loop Observer");
        }
    }
}

