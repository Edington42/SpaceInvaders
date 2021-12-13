using SpaceInvaders.Composite;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Composites
{
    /// <summary>
    /// Iterates through components depth first 
    /// </summary>
    public class ForwardIterator : Iterator
    {
        Component pRoot;
        Component pCurrent;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Costructor
        /// </summary>
        /// <param name="pStart">Initial component to iterate from </param>
        public ForwardIterator(Component pStart)
        {
            this.pCurrent = pStart;
            this.pRoot = pStart;
        }

        private Component FindNext(Component pChild, Component pSibling, Component pParent)
        {
            Component pNode = null;
            //Check the child then the sibling and then the parent
            if (pChild != null)
            {
                pNode = pChild;
            }
            else
            {
                if (pSibling != null)
                {
                    pNode = pSibling;
                }
                else
                {
                    //Check for a sibling to any of this node's parents but do not pass the root node
                    while (pParent != null)
                    {
                        pNode = pParent.GetSibling();
                        if (pNode != null)
                        {
                            //Sibling was found
                            break;
                        }
                        else
                        {
                            pParent = pParent.GetParent();
                            if (pParent == pRoot)
                            {
                                break;
                            }
                        }
                        //If we got here then pNode is null
                    }
                }
            }

            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override Component First()
        {
            Component pNode = this.pRoot;

            this.pCurrent = pNode;

            return this.pCurrent;
        }

        public override bool IsDone()
        {
            return this.pCurrent == null;
        }

        public override Component Next()
        {
            Component pNode = this.pCurrent;

            Component pChild = pNode.GetFirstChild();
            Component pSibling = pNode.GetSibling();
            Component pParent = pNode.GetParent();

            this.pCurrent = this.FindNext(pChild, pSibling, pParent);

            return pNode;

        }

        

    }
}
