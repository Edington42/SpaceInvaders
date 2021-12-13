using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class StopSoundEvent : Command
    {
        private Sound.Name name;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pObj">Component collection that will be moved.</param>
        public StopSoundEvent(Sound.Name name)
        {
            this.name = name;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            SoundManager.GetInstance().Find(name).StopLoop();
        }
    }
}
