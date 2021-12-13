using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Manager
{
    /// <summary>
    /// Manages nodes with priority
    /// </summary>
    public abstract class PriorityManager : Manager
    {
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        protected PriorityManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
        }

        /// <summary>
        /// Adds a priority node to the next spot in priority
        /// </summary>
        /// <param name="comparable">Priority to use for additon</param>
        /// <returns>newly added node</returns>
        public PDLink BaseAdd(IComparable comparable)
        {
            PDLink next = FindNextHighest(comparable);

            PDLink pNode;
            if (next != null)
            {
                pNode = (PDLink)BaseAddBefore(next);
            }
            else
            {
                pNode = (PDLink)BaseAddEnd();
            }

            return pNode;
        }

        /// <summary>
        /// Finds the next node in priority.  
        /// </summary>
        /// <param name="comparable">Priority being compared to</param>
        /// <returns>Next node in priority, null if there is none</returns>
        public PDLink FindNextHighest(IComparable comparable)
        {
            PDLink nextLink = (PDLink)BaseGetActive();
            while (nextLink != null)
            {
                if (nextLink.HasHigherPriority(comparable))
                {
                    return nextLink;
                }
                nextLink = (PDLink)nextLink.pNext;
            }
            return null;
        }

    }
}
