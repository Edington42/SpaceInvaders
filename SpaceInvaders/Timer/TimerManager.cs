using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    /// <summary>
    /// Manages timer events.  Singleton.
    /// </summary>
    public class TimerManager : PriorityManager
    {
        private static TimerManager pActiveMan = null;

        //Compare node
        private readonly TimerEvent poNodeCompare;

        //Current time in the manager
        static public float mCurrTime;

        //Time this manager was paused
        protected float mPauseTime;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public TimerManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new TimerEvent();
            this.mPauseTime = -1;
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static TimerManager GetInstance()
        {
            return TimerManager.pActiveMan;
        }

        public static void SetActive(TimerManager pMan)
        {
            TimerManager.pActiveMan = pMan;
        }

        /// <summary>
        /// Creates a timer event and adds it to the list based on priority
        /// </summary>
        /// <param name="name">Name of layer</param>
        /// /// <param name="pCommand">Command tied to the event.</param>
        /// /// <param name="deltaTimeToTrigger">Time between addition of event and triggering of the event.</param>
        /// <returns>Newly created layer</returns>
        public TimerEvent Add(TimerEvent.Name name, Command pCommand, float deltaTimeToTrigger)
        {

            TimerEvent pNode = (TimerEvent)BaseAdd(this.GetCurrTime() + deltaTimeToTrigger);

            //Initialize the data
            pNode.Set(name, pCommand, deltaTimeToTrigger);

            return pNode;
        }

        /// <summary>
        /// Updates the time for the manager.
        /// </summary>
        /// <param name="totalTime">Total time passed to be usd by the manager.</param>
        public void Update(float totalTime)
        {
            //If this was paused, then resume now
            if (this.mPauseTime > 0)
            {
                this.Resume(totalTime);
            }

            // squirrel away
            TimerManager.mCurrTime = totalTime;

            // walk the list
            TimerEvent pEvent = (TimerEvent)this.BaseGetActive();
            TimerEvent pNextEvent = null;

            // Walk the list until there is no more list OR currTime is greater than timeEvent 
            while (pEvent != null && TimerManager.mCurrTime >= pEvent.triggerTime)
            {
                // Difficult to walk a list and remove itself from the list
                // so squirrel away the next event now, use it at bottom of while
                pNextEvent = (TimerEvent)pEvent.pNext;
                    // call it
                    pEvent.Process();

                    // remove from list
                    this.Remove(pEvent);

                // advance the pointer
                pEvent = pNextEvent;
            }
        }

        /// <summary>
        /// Gets the current time of the manager.
        /// </summary>
        /// <returns>Current timer of the manager.</returns>
        public float GetCurrTime()
        {
            // return time
            return TimerManager.mCurrTime;
        }

        public TimerEvent Find(TimerEvent.Name name)
        {
            this.poNodeCompare.name = name;
            TimerEvent pEevent = (TimerEvent)this.BaseFind(poNodeCompare);
            return pEevent;
        }

        public void Pause()
        {
            this.mPauseTime = TimerManager.mCurrTime;
        }

        public void Resume(float toCatchUpTo)
        {
            float delta = toCatchUpTo - this.mPauseTime;

            //Walk the list and add time to all the timers
            // walk the list
            TimerEvent pEvent = (TimerEvent)this.BaseGetActive();

            // Walk the list  
            while (pEvent != null )
            {
                //Update the trigger
                pEvent.triggerTime += delta;

                // advance the pointer
                pEvent = (TimerEvent)pEvent.pNext;
            }

            //We are no longer paused
            this.mPauseTime = -1;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            TimerEvent layerA = (TimerEvent)nodeA;
            TimerEvent layerB = (TimerEvent)nodeB;

            bool match = false;

            if (layerA.name == layerB.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new TimerEvent();
        }

        protected override void Wash(DLink pNode)
        {
            TimerEvent pLayerNode = (TimerEvent)pNode;
            pLayerNode.Wash();
        }
    }
}
