using SpaceInvaders.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class BombDropRepeatCommand : DecayingRepeatCommand
    {
        public BombDropRepeatCommand(TimerEvent.Name name, Command command, float deltaRepeatTime) : base(name, command, deltaRepeatTime)
        {
        }

        protected override float GetDecayedDelta()
        {
            //Check the score to adjust the speed
            int score = ScoreKeeper.GetInstance().GetScore();


            //Esentially for every 1000 points, bombs speed up by .25
            float newTrigger = initialDelta - (score / 4000);

            //Catch just in case. lazy because it probably wont happen.  Max speed at 6000 points
            if (newTrigger < .25) newTrigger = .25f;

            return newTrigger;
        }
    }
}
