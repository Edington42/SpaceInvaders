using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class CommandTriggerObserver : Observer
    {
        Command pCommand;
        float delta;
        TimerEvent.Name commandName;

        //TODO this is how I should do other observers that just load events
        public CommandTriggerObserver(Command pCommand, float delta, TimerEvent.Name commandName)
        {
            this.pCommand = pCommand;
            this.delta = delta;
            this.commandName = commandName;
            
        }

        public override void Notify()
        {
            TimerManager.GetInstance().Add(this.commandName, this.pCommand, this.delta);
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
