using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    /// <summary>
    /// Container for a command that will have it repeat.
    /// </summary>
    public class RepeatCommand : Command
    {
        private Command command;
        public float repeatDelta;
        private TimerEvent.Name name;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the event this command is tied to.</param>
        /// <param name="command">Command to be repeated.</param>
        /// <param name="deltaRepeatTime">Time between instatiation/execution and the next execution.</param>
        public RepeatCommand(TimerEvent.Name name, Command command, float deltaRepeatTime)
        {
            this.command = command;
            this.repeatDelta = deltaRepeatTime;
            this.name = name;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            command.Execute(deltaTime);

            TimerManager.GetInstance().Add(this.name, this, this.repeatDelta);
        }
    }
}
