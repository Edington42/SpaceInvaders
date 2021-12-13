using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class SndStopLoopObserver : Observer
    {
        Sound.Name name;

        public SndStopLoopObserver(Sound.Name name)
        {
            this.name = name;
        }

        public override void Notify()
        {
            Sound pNode = (Sound)SoundManager.GetInstance().Find(this.name);
            pNode.StopLoop();
        }

        public override void Print()
        {
            Debug.WriteLine("Sound Stop Loop Observer");
        }
    }
}
