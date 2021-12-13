using SpaceInvaders.Layer;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    public class RemoveFromLayerEvent : Command
    {
        protected Layer.Layer.Name layerName;
        protected ProxySprite pProxySprite;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pObj">Component collection that will be moved.</param>
        public RemoveFromLayerEvent(Layer.Layer.Name name, ProxySprite pProxySprite)
        {
            this.layerName = name;
            this.pProxySprite = pProxySprite;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            LayerManager.GetInstance().Remove(layerName, pProxySprite);
            ProxySpriteManager.GetInstance().Remove(pProxySprite);
        }
    }
}
