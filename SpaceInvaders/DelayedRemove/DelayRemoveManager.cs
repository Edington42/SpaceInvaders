using SpaceInvaders.Composite;
using SpaceInvaders.Composites;
using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.DelayedRemove
{
    public class DelayRemoveManager
    {
        private static DelayRemoveManager instance = new DelayRemoveManager();
        private DLink pHead;
        private DLink pTail;

        public static DelayRemoveManager GetInstance()
        {
            return instance;
        }

        private DelayRemoveManager()
        {
            pHead = null;
            pTail = null;
        }

        public void Attach(Leaf pNode)
        {
            //Make sure the incoming remove event is not already here
            if (pNode.markedForDeath == false)
            {
                pNode.markedForDeath = true;
                DLink.InsertFront(ref pHead, ref pTail, new DelayRemoveNode(pNode));
            }
        }

        public void Process()
        {
            DelayRemoveNode pNode = (DelayRemoveNode)this.pHead;

            while(pNode != null)
            {
                pNode.Execute();
                pNode.Remove(ref pHead, ref pTail);
                pNode = (DelayRemoveNode)this.pHead;
            }


        }

    }
}
