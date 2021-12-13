using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    public abstract class DecayingRepeatCommand : RepeatCommand
    {
        protected float initialDelta;
        public DecayingRepeatCommand(TimerEvent.Name name, Command command, float deltaRepeatTime) 
            : base(name, command, deltaRepeatTime)
        {
            this.initialDelta = repeatDelta;
        }

        public override void Execute(float deltaTime)
        {
            this.repeatDelta = this.GetDecayedDelta();
            base.Execute(deltaTime);
        }

        protected abstract float GetDecayedDelta();


    }
}
