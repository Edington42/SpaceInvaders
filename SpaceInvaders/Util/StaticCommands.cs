using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Input;
using SpaceInvaders.Layer;
using SpaceInvaders.Sounds;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Util
{
    public class StaticCommands
    {

        public static void Splat(GameSpriteNode.Name splatName, Layer.Layer.Name splatLayerName, GameObject toSplat)
        {
            LayerManager pManager = LayerManager.GetInstance();
            ProxySprite pProxySprite = ProxySpriteManager.GetInstance().Add(splatName, toSplat.x, toSplat.y);
            pManager.AttachToLayer(splatLayerName, pProxySprite);
            RemoveFromLayerEvent removeEnvent = new RemoveFromLayerEvent(splatLayerName, pProxySprite);
            TimerManager.GetInstance().Add(TimerEvent.Name.REMOVE_FROM_LAYER, removeEnvent, .25f);
        }
    }
}
