using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SpaceInvaders.Sounds;

namespace SpaceInvaders.Observer
{
    public class SoundLoopObserver : Observer
    {
        SCircleManager pSoundLoop;

        public SoundLoopObserver()
        {
            this.pSoundLoop = new SCircleManager();
        }

        public void Attach(Sound.Name name)
        {
            SoundNode pNode = new SoundNode(SoundManager.GetInstance().Find(name));
            pSoundLoop.Add(pNode);
        }

        public override void Notify()
        {
              SoundNode pNode = (SoundNode)pSoundLoop.GetNext();
            pNode.pSound.Play();
        }


        public override void Print()
        {
            Debug.WriteLine("Sound loop observer");
        }
    }
}
