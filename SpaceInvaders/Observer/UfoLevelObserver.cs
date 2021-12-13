using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    //Special case if ufo is around during a level cange
    class UfoLevelObserver : Observer
    {
        public override void Notify()
        {
            UfoManager pMan = UfoManager.GetInstance();
            if (pMan.flying)
            {
                Sound pNode = (Sound)SoundManager.GetInstance().Find(Sound.Name.UFO);
                pNode.StopLoop();
                pMan.PrepUfo();
            }
        }

        public override void Print()
        {
            Debug.WriteLine("Ufo level observer");
        }
    }
}
