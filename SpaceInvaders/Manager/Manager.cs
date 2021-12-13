using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Manager
{
    public abstract class Manager
    {

        //Attributes of active list
        protected DLink pActive;
        protected DLink pActiveTail;
        protected int mNumActive = 0;

        //Attributues of reserve list
        private DLink pReserve;
        private DLink pReserveTail;
        public int mNumReserved = 0;
        private int growthSize;

        /// <summary>
        /// Returns a blank instance of a DLink
        /// </summary>
        /// <returns>Washed instance of a DLink</returns>
        protected abstract DLink GetBlank();

        /// <summary>
        /// Compares nodes
        /// </summary>
        /// <param name="nodeA">First node to compare</param>
        /// <param name="nodeB">Second node to compare</param>
        /// <returns>True if the nodes match</returns>
        protected abstract bool CompareNodes(DLink nodeA, DLink nodeB);

        /// <summary>
        /// Clears state from the given node
        /// </summary>
        /// <param name="pNode">Node to clear state from</param>
        protected abstract void Wash(DLink pNode);

        /// <summary>
        /// Creates a manger of a pooled memory Double Linked List
        /// </summary>
        /// <param name="reserveSize">Initial size of the reserve pool</param>
        /// <param name="growthSize">Size the reserve pool will grow by</param>
        protected Manager(int reserveSize, int growthSize)
        {
            this.growthSize = growthSize;

            Grow(reserveSize);
        }

        /// <summary>
        /// Grows the reserve by the groth size
        /// </summary>
        private void Grow()
        {
            Grow(this.growthSize);
        }

        /// <summary>
        /// Grows the reserve by the given size.
        /// </summary>
        /// <param name="growthSize">Size to grow the reserve by.</param>
        private void Grow(int growthSize)
        {
            for (int i = 0; i < growthSize; i++)
            {
                DLink.InsertFront(ref this.pReserve, ref this.pReserveTail, GetBlank());
                mNumReserved++;
            }
        }

        /// <summary>
        /// Grabs a node off the reserve, cleans it and returns it
        /// </summary>
        /// <returns>New Node</returns>
        protected DLink BaseAdd()
        {
            //Get node from reserve
            DLink node = GrabNode();

            //Clean it
            this.Wash(node);

            //Add it to the active list
            DLink.InsertFront(ref pActive, ref pActiveTail, node);
            mNumActive++;

            //Return it
            return node;
        }

        protected DLink BaseAddEnd()
        {
            //Get node from reserve
            DLink node = GrabNode();

            //Clean it
            this.Wash(node);

            //Add it to the end of the active list
            DLink.InsertEnd(ref pActive, ref pActiveTail, node);
            mNumActive++;

            //return it
            return node;
        }

        protected DLink BaseAddBefore(DLink before)
        {
            //Get node from resereve
            DLink node = GrabNode();

            //Clean it
            this.Wash(node);

            //Add it before the given node
            DLink.InsertBefore(ref pActive, before, node);
            mNumActive++;

            //return it
            return node;
        }

        /// <summary>
        /// Finds a target node within the manager
        /// </summary>
        /// <param name="pNodeTarget">Target node</param>
        /// <returns>Requested node</returns>
        protected DLink BaseFind(DLink pNodeTarget)
        {
            //Grab the active list
            DLink pNode = this.pActive;

            while(pNode != null)
            {
                if(CompareNodes(pNodeTarget, pNode))
                {
                    break;
                }
                //If node was not found set to the next node. If this was the last then this will be left as null
                pNode = pNode.pNext;
            }

            return pNode;
        }

        /// <summary>
        /// Returns the heaad of the active list for this manager
        /// </summary>
        /// <returns>Head of the active list</returns>
        protected DLink BaseGetActive()
        {
            return pActive;
        }

        /// <summary>
        /// Grabs a node from the reserve list.  Grows reserve if needed.
        /// </summary>
        /// <returns>Node from reserve list</returns>
        private DLink GrabNode()
        {
            //Check that reserve is not empty first, and if it is grow it
            if (pReserve == null) Grow();
            DLink fromReserve = pReserve;
            fromReserve.Remove(ref pReserve, ref pReserveTail);
            mNumReserved--;

            return fromReserve;
        }

        /// <summary>
        /// Removes a node from the active list
        /// </summary>
        /// <param name="toRemove">Node to be removed</param>
        public void Remove(DLink toRemove)
        {
            //Remove from active
            toRemove.Remove(ref pActive, ref pActiveTail);
            mNumActive--;

            //Clean the node 
            this.Wash(toRemove);

            //Add to reserve
            DLink.InsertFront(ref pReserve, ref pReserveTail, toRemove);
            mNumReserved++;
        }

        /// <summary>
        /// Removes the node from the active list but does not clean it up 
        /// </summary>
        /// <param name="pNode">Node to be removed</param>
        protected void TmpRemove(DLink pNode)
        {
            pNode.Remove(ref pActive, ref pActiveTail);
        }

       /// <summary>
       /// Puts the frist node behind the second node on the manager
       /// </summary>
       /// <param name="pNodeA">Node that will be first</param>
       /// <param name="pNodeB">Node that will be next</param>
        public void MoveBefore(DLink pNodeA, DLink pNodeB)
        {
            if(pNodeB == null)
            {
                DLink.InsertEnd(ref this.pActive, ref this.pActive, pNodeA);
            } 
            else
            {
                DLink.InsertBefore(ref this.pActive, pNodeB, pNodeA);
            }
        }

        /// <summary>
        /// Destroys the references in a manager
        /// </summary>
        protected static void BaseDestroy(Manager toDestroy)
        {
            //Clear the active list
            toDestroy.Empty();


            //Do the same for the reserve
            DLink pNode = toDestroy.pReserve;
            while (pNode != null)
            {
                //Probably don't have to wash them but still doing it in case
                toDestroy.Wash(pNode);
                pNode.Remove(ref toDestroy.pReserve, ref toDestroy.pReserveTail);
                toDestroy.mNumReserved--;
            }
        }

        /// <summary>
        /// Removes all of the nodes from the active list
        /// </summary>
        public void Empty()
        {
            //Clear the active list
            DLink pNode = this.pActive;
            while (pNode != null)
            {
                this.Wash(pNode);
                pNode.Remove(ref this.pActive, ref this.pActiveTail);
                this.mNumActive--;
            }
        }

        /// <summary>
        /// Prints the active list 
        /// </summary>
        public void PrintMe()
        {
            PrintUtil.PrintDividerText("Start PrintMe");

            DLink node = this.pActive;
            while (node != null)
            {
                node.Print();
                node = node.pNext;
            }
            PrintUtil.PrintDividerText("End PrintMe");
        }

        /// <summary>
        /// Prints the active list backwards 
        /// </summary>
        public void MePrint()
        {
            PrintUtil.PrintDividerText("Start MePrint");
            DLink node = this.pActiveTail;
            while (node != null)
            {
                node.Print();
                node = node.pPrevious;
            }
            PrintUtil.PrintDividerText("End MePrint");
        }

        /// <summary>
        /// Prints stats as well as the active list forwards and backwards
        /// </summary>
        public void Print()
        {
            PrintUtil.PrintBoarderedText("Start Print");
            Debug.WriteLine("Active Nodes: " + mNumActive);
            Debug.WriteLine("Reserve Nodes: " + mNumReserved);
            Debug.WriteLine("Growth Size: " + growthSize);
            PrintMe();
            MePrint();
            PrintUtil.PrintBoarderedText("End Print");
        }
    }
}
