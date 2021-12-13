using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
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
    /// Abstract leaf node of composite pattern 
    /// </summary>
    public abstract class Leaf : GameObject
    {
        public ProxySprite pProxySprite;

        /// <summary>
        /// Construcotr
        /// </summary>
        public Leaf()
            :base(GameObject.Name.NULL_OBJECT)
        {
            this.pProxySprite = ProxySpriteManager.GetInstance().Add(GameSpriteNode.Name.NULL_OBJECT, this.x, this.y);
            this.poColObj = new ColObject(this.pProxySprite);
            markedForDeath = false;
        }

        public void BaseSet(GameObject.Name gameName, GameSpriteNode.Name spriteName, float x, float y)
        {
            this.x = x;
            this.y = y;
            this.pProxySprite = ProxySpriteManager.GetInstance().Add(spriteName, this.x, this.y);
            this.poColObj.Set(this.pProxySprite.pNode.GetScreenRect());
            markedForDeath = false;
        }

        public void AttachGameSprite(Layer.Layer.Name layerName)
        {
            LayerManager.GetInstance().AttachToLayer(layerName, this.pProxySprite);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Update()
        {
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;
            this.poColObj.UpdatePos(this.x, this.y);
            this.poColObj.Update();
        }

        public override void Empty()
        {
            GameObject pParent = (GameObject)this.GetParent();
            pParent.Remove(this);

            //Remove the proxy sprite
            ProxySprite pProxy = this.pProxySprite;
            pProxy.pSpriteContainer.pSpriteContainerManager.Remove(pProxy);

            GameObject pToRemove = this;
            while (pToRemove != null)
            {
                BaseSpriteNode pColSprite = pToRemove.poColObj.pColSprite;
                pColSprite.pSpriteContainer.pSpriteContainerManager.Remove(pColSprite);

                if (pToRemove.backPointer != null)
                {
                    pToRemove.backPointer.pManager.Remove(pToRemove.backPointer);
                }
                
                if(pParent.GetFirstChild() == null)
                {
                    GameObject pParentParent = (GameObject)pParent.GetParent();

                    if (pParentParent != null)
                    {
                        pToRemove = pParent;
                        pParent = (GameObject)pToRemove.GetParent();
                        pParent.Remove(pToRemove);

                    }
                    else
                    {
                        //If there is no parent then this is a root and should be take care of
                        //TODO there is probably a better way to do this
                        pParent.x = 0;
                        pParent.y = 0;
                        pParent.poColObj.pColRect.Set(0, 0, 0, 0);
                        pParent.poColObj.Update();
                        pToRemove = null;
                    }
                } else
                {
                    pToRemove = null;
                }
            }
        }

        public override void Print()
        {
            Debug.WriteLine("Leaf " + this.name);
        }

        //TODO it isn't great that these have to be implemented 
        public override void Add(Component c)
        { 
            Debug.Assert(false);
        }

        public override void Remove(Component c)
        {
            Debug.Assert(false);
        }

        public override Component GetFirstChild()
        {
            //This is a leaf so it has no children.
            return null;
        }

        
    }
}
