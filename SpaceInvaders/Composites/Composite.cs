using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.Layer;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Composite
{
    /// <summary>
    /// Composite component that contains one or more leaves or components. 
    /// </summary>
    public abstract class Composite : GameObject
    {
        //Head and tail of doubly linked list
        public DLink poHead;
        public DLink poTail;

        public int numChildren;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Consructor. 
        /// </summary>
        public Composite(GameObject.Name gameName)
            : base(gameName)
        {
            this.poHead = null;
            this.poTail = null;
            this.poColObj = new ColObject();
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Add(Component pComponent)
        {
            DLink.InsertFront(ref this.poHead, ref this.poTail, pComponent);
            pComponent.pParent = this;
            numChildren++;
        }

        public override void Print()
        {
            Debug.WriteLine("Container " + this.name + "-------------------------");
        }

        public override void Remove(Component pComponent)
        {
            pComponent.Remove(ref poHead, ref poTail);
            numChildren--;
        }

        protected override void ToDefault()
        {
            this.poHead = null;
            this.poTail = null;
        }

        public override void Update()
        {

            ColRect pColTotal = this.poColObj.pColRect;
            GameObject pNode = (GameObject)this.GetFirstChild();
            if(pNode != null)
            {
                pColTotal.Set((pNode.GetColObject().pColRect));//Initilize to the first child's size
                pNode = (GameObject)pNode.GetSibling();

                while (pNode != null)
                {

                    pColTotal.Union(pNode.poColObj.pColRect);
                    pNode = (GameObject)pNode.GetSibling();


                }

                this.x = pColTotal.x;
                this.y = pColTotal.y;

                this.poColObj.UpdatePos(this.x, this.y);
                this.poColObj.Update();
            }

        }

        public override void Empty()
        {
            GameObject pNode = (GameObject)this.GetFirstChild();
            while (pNode != null)
            {
                pNode.Empty();
                pNode = (GameObject)this.GetFirstChild();
            }
        }

        public override Component GetFirstChild()
        {
            return (Component)this.poHead;
        }
    }
}
