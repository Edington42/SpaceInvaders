using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    public class Subject
    {
        private DLink pHead;
        private DLink pTail;
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Attaches an observer to this subject
        /// </summary>
        /// <param name="observer">Observer to attach</param>
        public void Attach(Observer observer)
        {
            observer.pSubject = this;

            DLink.InsertFront(ref pHead, ref pTail, observer);
        }

        /// <summary>
        /// Notifies all observers 
        /// </summary>
        public void Notify()
        {
            Observer pNode = (Observer)this.pHead;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify();

                pNode = (Observer)pNode.pNext;
            }
        }

        public void Remove(DLink pNode)
        {
            pNode.Remove(ref this.pHead, ref this.pTail);
        }

        /// <summary>
        /// Clears the observers from this subject
        /// </summary>
        public void Clear()
        {
            DLink.RemoveAll(ref pHead, ref pTail);
        }
    }
}
