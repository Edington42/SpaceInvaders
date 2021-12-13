using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Manager
{
    /// <summary>
    /// Manages a circular, singly linked list.
    /// </summary>
    public class SCircleManager
    {
        private SLink pCurrNode;
        private SLink poFirstNode;

        /// <summary>
        /// Gets the next node in the list
        /// </summary>
        /// <returns>Next node in the list</returns>
        public SLink GetNext()
        {
            //Get the next node
            SLink pLink = pCurrNode.pNext;

            //If we are at the end, return to the front
            if(pLink == null)
            {
                pLink = poFirstNode;
            }

            //Hold on
            this.pCurrNode = pLink;

            return this.pCurrNode;
        }

        /// <summary>
        /// Adds a node to the front of the list
        /// </summary>
        /// <param name="pLink">Node to add</param>
        public void Add(SLink pLink)
        {
            // Attach the node to the front of the list
            SLink.AddToFront(ref this.poFirstNode, pLink);

            this.pCurrNode = pLink;
        }
    }
}
