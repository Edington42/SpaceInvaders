using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Manager
{
    /// <summary>
    /// Single linked list
    /// </summary>    
    public abstract class SLink
    {
        public SLink pNext;

        /// <summary>
        /// Constructor
        /// </summary>
        public SLink()
        {
            this.pNext = null;
        }

        /// <summary>
        /// Adds a given node to the head of a list
        /// </summary>
        /// <param name="pHead">head of list to add to</param>
        /// <param name="pNode">Ndoe to add</param>
        public static void AddToFront(ref SLink pHead, SLink pNode)
        {
            if (pHead == null)
            {
                pNode.pNext = null;
            }
            else
            {
                pNode.pNext = pHead;
            }
            pHead = pNode;
        }

    }

    

}
