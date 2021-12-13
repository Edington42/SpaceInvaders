using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.Layer;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ShipSplatObserver : Observer
    {
        Layer.Layer.Name layerName;
        GameSpriteNode.Name spriteName;

        public ShipSplatObserver(Layer.Layer.Name layerName, GameSpriteNode.Name spriteName) :
            base()
        {
            this.layerName = layerName;
            this.spriteName = spriteName;
        }

        public override void Notify()
        {
            GameObject toSplat = ShipManager.GetInstance().GetShip();
            StaticCommands.Splat(this.spriteName, this.layerName, toSplat);
        }

        public override void Print()
        {
            Debug.WriteLine("Splat Observer");
        }
    }
}
