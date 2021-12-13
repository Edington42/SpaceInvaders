using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class SndStartLoopObserver : Observer
    {
        Sound.Name name;

        public SndStartLoopObserver(Sound.Name name)
        {
            this.name = name;
        }

        public override void Notify()
        {
            Sound pNode = (Sound)SoundManager.GetInstance().Find(this.name);
            pNode.PlayLoop();
        }

        public override void Print()
        {
            Debug.WriteLine("Sound Start Loop Observer");
        }
    }
}

