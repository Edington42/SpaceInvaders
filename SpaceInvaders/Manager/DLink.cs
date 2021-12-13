using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class DLink
    {
        public DLink pNext;
        public DLink pPrevious;

        public DLink()
        {
            pNext = null;
            pPrevious = null;
        }

        /// <summary>
        /// Sets the node to its default
        /// </summary>
        protected abstract void ToDefault();

        /// <summary>
        /// Prints the details of the node to the debug console
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Washes the node
        /// </summary>
        public void Wash()
        {
            this.ToDefault();
        }

        /// <summary>
        /// Inserts a node to the front of a list
        /// </summary>
        /// <param name="head">Head of list being inserted to</param>
        /// <param name="tail">tail of list being inserted to</param>
        /// <param name="newNode">Node to be inserted</param>
        public static void InsertFront(ref DLink head, ref DLink tail, DLink newNode)
        {
            if (!InsertIfEmpty(ref head, ref tail, newNode))
            {
                //If the node was not added to an empty list then insert at head
                head.pPrevious = newNode;
                newNode.pNext = head;
                head = newNode;
            }
        }

        /// <summary>
        /// Inserts a node before another given node
        /// </summary>
        /// <param name="head">Head of list to be inserted to</param>
        /// <param name="toInsertBefore">Node to be inserted before</param>
        /// <param name="newNode">Node to insert</param>
        public static void InsertBefore(ref DLink head, DLink toInsertBefore, DLink newNode)
        {
            //Check if this was the head of the list, and if so make this the new head
            DLink previous = toInsertBefore.pPrevious;
            if (previous == null)
            {
                head = newNode;
            }
            //Otherwise just link the new node to the previous node
            else
            {
                newNode.pPrevious = previous;
                previous.pNext = newNode;
            }

            //Then link to the next node
            newNode.pNext = toInsertBefore;
            toInsertBefore.pPrevious = newNode;
        }

        /// <summary>
        /// Inserts a node after a given node
        /// </summary>
        /// <param name="tail">tail of list to be inserted to</param>
        /// <param name="toInsertAfter">Node to be inserted after</param>
        /// <param name="newNode">Node to insert</param>
        public static void InsertAfter(ref DLink tail, DLink toInsertAfter, DLink newNode)
        {
            //Check if this was the tail of the list, and if so make this the new tail
            DLink next = toInsertAfter.pNext;
            if (next == null)
            {
                tail = newNode;
            }
            //Otherwise just link the new node to the next node
            else
            {
                newNode.pNext = next;
                next.pPrevious = newNode;
            }

            //Then link to the previous node
            newNode.pPrevious = toInsertAfter;
            toInsertAfter.pNext = newNode;
        }

        /// <summary>
        /// Inserts a node to the tail of a list
        /// </summary>
        /// <param name="head">Head of list being inserted to</param>
        /// <param name="tail">tail of list being inserted to</param>
        /// <param name="newNode">Node to be inserted</param>
        public static void InsertEnd(ref DLink head, ref DLink tail, DLink newNode)
        {

            if (!InsertIfEmpty(ref head, ref tail, newNode))
            {
                //If the node was not added to an empty list then insert at tail
                tail.pNext = newNode;
                newNode.pPrevious = tail;
                tail = newNode;
            }

        }

        /// <summary>
        /// Checks if the list is empty and if so inserts the node into the list and returns true.  Otherwise returns false.
        /// </summary>
        /// <param name="head">Head of list</param>
        /// <param name="tail">Tail of list</param>
        /// <param name="newNode">Node to be added</param>
        /// <returns>True if the node was inserted</returns>
        private static bool InsertIfEmpty(ref DLink head, ref DLink tail, DLink newNode)
        {
            if (head == null || tail == null)
            {
                head = newNode;
                tail = newNode;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes this node from whatever list it is in
        /// </summary>
        /// <param name="head">Head of the list containing this node</param>
        /// <param name="tail">tail of the list containing this node</param>
        public void Remove(ref DLink head, ref DLink tail)
        {
            //Should assert that this node is in the list

            DLink nextNode = this.pNext;
            DLink previousNode = this.pPrevious;

            //If the next node not null then it's previous should become this nodde's previous
            if (nextNode != null)
            {
                nextNode.pPrevious = previousNode;
            }
            //Otherwise the next node becomes the tail
            else
            {
                tail = previousNode;
            }

            //If the previous node not null then it's next should become this nodde's next
            if (previousNode != null)
            {
                previousNode.pNext = nextNode;
            }
            //Otherwise the next node becomes the head 
            else
            {
                head = nextNode;
            }

            //Finally, clean this node
            this.Clear();
        }

        /// <summary>
        /// Removes all of the nodes from the provided list
        /// </summary>
        /// <param name="head">Head of the list</param>
        /// <param name="tail">Tail of the list</param>
        public static void RemoveAll(ref DLink head, ref DLink tail)
        {
            DLink pNode = head;
            while(pNode != null)
            {
                pNode.Remove(ref head, ref tail);
            }
            head = null;
            tail = null;
        }

        public void Clear()
        {
            this.pNext = null;
            this.pPrevious = null;
        }
    }
}