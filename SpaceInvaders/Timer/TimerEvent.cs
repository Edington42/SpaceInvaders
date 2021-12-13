using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    /// <summary>
    /// Timer based event.
    /// </summary>
    public class TimerEvent : PDLink
    {
        public Name name;
        public Command pCommand;
        public float triggerTime;
        float deltaTime;

        /// <summary>
        /// Enum of layer names
        /// </summary>
        public enum Name
        {

            REPEAT_1,
            REPEAT_2,
            SQUID,
            CRAB,
            OCTO,
            MOVE_ALIENS,
            MOVE_MISSILE,
            UNINITIALIZED,
            MOVE_BOMBS,
            DROP_BOMB,
            MissileSpawn,
            BombSpawn,
            SQUIGLY,
            PLUNGER,
            ROLLING,
            REMOVE_FROM_LAYER,
            RESET,
            CLEAR_COMMAND,
            RESUME,
            SHIP_BOOM,
            STOP_SHIP_BOOM,
            RESET_SHIP,
            LIFE_LOST,
            HIDE_LIVES,
            RESET_LIVES,
            UFO_LAUNCH,
            MOVE_UFO,
            LAND,
            UFO_SOUND,
            TRANSITION,
            SHOW_OVER,
            TRANSITION_SELECT,
            HIDE_OVER,
            DEATH_TRANSITION,
            TABULATE,
            RESET_LEVEL,
            RERACK,
            TRANSITION_RESET
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        public TimerEvent() : base()
        {
            this.name = TimerEvent.Name.UNINITIALIZED;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }


        /// <summary>
        /// Sets the name trigger and command for the timer event
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="pCommand">Command for the event</param>
        /// <param name="deltaTimeToTrigger">Time from now that the event should trigger</param>
        public void Set(Name name, Command pCommand, float deltaTimeToTrigger)
        {
            this.name = name;
            this.pCommand = pCommand;
            this.deltaTime = deltaTimeToTrigger;

            // set the trigger time
            this.triggerTime = TimerManager.GetInstance().GetCurrTime() + deltaTimeToTrigger;
        }

        /// <summary>
        /// Process the command event
        /// </summary>
        public void Process()
        {
            this.pCommand.Execute(deltaTime);
        }
        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine("Timmer event:" + this.name + " At:" + this.triggerTime);
        }

        protected override void ToDefault()
        {
            this.name = Name.UNINITIALIZED;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public override bool HasHigherPriority(IComparable comparable)
        {
            return (this.triggerTime.CompareTo((float)comparable) > 0);
        }
    }
}
