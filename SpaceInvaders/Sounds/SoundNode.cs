using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sounds
{
    public class SoundNode : SLink
    {
        public Sound pSound;

        public SoundNode(Sound pSound)
        {
            this.pSound = pSound;
        }
    }
}
