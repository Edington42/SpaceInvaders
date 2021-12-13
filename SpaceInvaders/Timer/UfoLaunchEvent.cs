using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class UfoLaunchEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            UfoManager.GetInstance().LunchUfo();
        }
    }
}
