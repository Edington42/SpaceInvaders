using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    public abstract class Observer : DLink
    {
        public Subject pSubject;

        //---------------------------------------------------------------------------------------------------------
        // Override methods
        //---------------------------------------------------------------------------------------------------------
        protected override void ToDefault()
        {
            this.pSubject = null;
        }

        //---------------------------------------------------------------------------------------------------------
        // Abstract methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Method used to notify this observer that an event occured
        /// </summary>
        abstract public void Notify();
    }
}
